using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using Domain;

namespace Session
{
    public class Broker
    {
        private static Broker _instance;
        private OleDbCommand _command;
        private OleDbConnection _connection;
        private OleDbTransaction _transaction;

        private Broker()
        {
            Connect();
        }

        private void Connect()
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            _connection = new OleDbConnection(connString);
            _command = _connection.CreateCommand();
        }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Error while establishing connection!");
            }
        }

        public void CloseConnection()
        {
            try
            {
                _connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error while closing connection!");
            }
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {
                throw new Exception("Error while starting transaction!");
            }
        }

        public void Save()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Error while commiting!");
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            catch (Exception)
            {
                throw new Exception("Error while rollbacking!");
            }
        }

        public static Broker GetSession()
        {
            return _instance ?? (_instance = new Broker());
        }

        public bool Input(IGenericObject obj)
        {
            try
            {
                var query = "INSERT INTO " + obj.GetTableName() + " " + obj.GetInsertColumns() + " VALUES " + obj.GetInsertValues();
                _command = new OleDbCommand(query, _connection, _transaction);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<IGenericObject> GetAllObjects(IGenericObject obj)
        {
            try
            {
                var query = "SELECT * FROM " + obj.GetTableName();
                _command = new OleDbCommand(query, _connection, _transaction);
                var reader = _command.ExecuteReader();
                return obj.GetList(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaxId(IGenericObject obj)
        {
            try
            {
                var query = "Select Max(" + obj.GetPrimaryKeyName() + ") as MaxBroj from " + obj.GetTableName();
                _command = new OleDbCommand(query, _connection, _transaction);
                var reader = _command.ExecuteReader();

                if (reader != null && !reader.Read()) return 1;
                try
                {
                    if (reader != null)
                    {
                        return Convert.ToInt32(reader["MaxBroj"]) + 1;
                    }
                }
                catch
                {
                    // ignored
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IGenericObject GetObjectByCondition(IGenericObject obj)
        {
            try
            {
                var query = "SELECT * FROM " + obj.GetTableName() + " WHERE " + obj.GetCondition();
                _command = new OleDbCommand(query, _connection, _transaction);
                var reader = _command.ExecuteReader();

                return obj.GetObject(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IGenericObject> GetAllObjectsByCondition(IGenericObject obj)
        {
            try
            {
                var query = "SELECT * FROM " + obj.GetTableName() + " WHERE " + obj.GetCondition();
                _command = new OleDbCommand(query, _connection, _transaction);
                var reader = _command.ExecuteReader();

                return obj.GetList(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(IGenericObject obj)
        {
            try
            {
                var query = "DELETE  FROM " + obj.GetTableName() + " WHERE " + obj.GetPrimaryKeyValue();
                _command = new OleDbCommand(query, _connection, _transaction);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(IGenericObject obj)
        {
            try
            {
                var query = "UPDATE " + obj.GetTableName() + " SET " + obj.GetUpdateValues() + " WHERE " +
                           obj.GetPrimaryKeyValue();
                _command = new OleDbCommand(query, _connection, _transaction);
                _command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}