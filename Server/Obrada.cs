using Domen;
using KontrolerAplikacioneLogike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Server
{
    public class Obrada
    {

        private NetworkStream tok;
        BinaryFormatter formater;
        KontrolerAL kal;

        public Obrada(NetworkStream tok)
        {

            this.tok = tok;
            formater = new BinaryFormatter();
            kal = new KontrolerAL();

            ThreadStart ts = obradi;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        void obradi()
        {
            int operacija = 0;
            while (operacija != (int)Operacije.kraj)
            {
                TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                switch (transfer.Operacija)
                {
                    //case (Operacije.VratiReferente):
                    //    VratiReferenta vr = new VratiReferenta();
                    //    transfer.Rezultat = vr.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiGrupe):
                    //    VratiGrupe vg = new VratiGrupe();
                    //    transfer.Rezultat = vg.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiOpstine):
                    //    VratiOpstine vo = new VratiOpstine();
                    //    transfer.Rezultat = vo.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.SacuvajDete):
                    //    SacuvajDete sd = new SacuvajDete();
                    //    transfer.Rezultat = sd.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiDecu):
                    //    VratiDecu vd = new VratiDecu();
                    //    transfer.Rezultat = vd.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.IzmeniDete):
                    //    IzmeniDete id = new IzmeniDete();
                    //    transfer.Rezultat = id.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.PretraziDete):
                    //    PretraziDete pd = new PretraziDete();
                    //    transfer.Rezultat = pd.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.ObrisiDete):
                    //    IspisiDete isd = new IspisiDete();
                    //    transfer.Rezultat = isd.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.PretraziGrupe):
                    //    PretraziGrupe pg = new PretraziGrupe();
                    //    transfer.Rezultat = pg.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.KreirajRacun):
                    //    KreirajRacun kr = new KreirajRacun();
                    //    transfer.Signal = Convert.ToInt32(kr.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat));
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiUsluge):
                    //    VratiUsluge vu = new VratiUsluge();
                    //    transfer.Rezultat = vu.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.SacuvajRacun):
                    //    SacuvajRacun sr = new SacuvajRacun();
                    //    transfer.Rezultat = sr.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    ////case (Operacije.SacuvajStavkeRacun):
                    ////    SacuvajStavke ss = new SacuvajStavke();
                    ////    transfer.Rezultat = ss.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    ////    formater.Serialize(tok, transfer);
                    ////    break;
                    //case Operacije.PrikazRacunaUGridu:
                    //    PrikazRacuna pr = new PrikazRacuna();
                    //    transfer.Rezultat = pr.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;

                    //case Operacije.StornirajRacun:
                    //    StornirajRacun st = new StornirajRacun();
                    //    transfer.Rezultat = st.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiReprezentaciju):
                    //    VratiReprezentacije vre = new VratiReprezentacije();
                    //    transfer.Rezultat = vre.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    //case (Operacije.VratiReprezentacijuZaUslov):
                    //    VratiReprezentacijuZaUslov vru = new VratiReprezentacijuZaUslov();
                    //    transfer.Rezultat = vru.izvrsiSo(transfer.TransferObjekat as OpstiDomenskiObjekat);
                    //    formater.Serialize(tok, transfer);
                    //    break;
                    case Operacije.VratiImenaZaposlenih:
                        transfer.TransferObjekat = kal.VratiImenaZaposlenih();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.PrijaviZaposlenog:
                        transfer.TransferObjekat = kal.PrijaviZaposlenog(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.PronadjiZaposlenog:
                        transfer.TransferObjekat = kal.PronadjiZaposlenog(transfer.TransferObjekat as String);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.kraj:
                        operacija = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
