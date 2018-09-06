using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MK_HelperDataLib
{
   public class RaporSelect : IDisposable
    {
       public static SqlConnection con = new SqlConnection();
        public static System.Data.DataTable S_GETIHBAR_RAPOR(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger,string where)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,I_IHBARTUR  FROM I_IHBAR I  left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID left join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID left join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID left join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON like '" + ihbarcitel + "%'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM like '" + ihbarciadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN ("+ilce+")";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE IN ("+mahalle+")";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE like '%"+cadde+"%'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA=@I_PLAKA";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR IN ("+ustolay+")";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU IN ("+altolay+")";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  I.I_DURUM IN (" + aramadurum + ")";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
                }
            }
            if (where != "")
            {
                sorgu += where.Replace("where","and");
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
            //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
            daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
            //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
            daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
            daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
            daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
            daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında ihbar raporu sorguladı", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_RAPOR_ARAMALISTESI(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string where)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,I_IHBARTUR  FROM I_IHBAR I  left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID left join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID left join I_USTOLAY  US ON I.I_USTOLAYKODU=convert(varchar(25),US.U_ID ) left join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON = '" + ihbarcitel + "'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM = '" + ihbarciadi + "'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE IN (" + mahalle + ")";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE = '" + cadde + "'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA=@I_PLAKA";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR IN (" + ustolay + ")";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU IN (" + altolay + ")";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  I.I_DURUM IN (" + aramadurum + ")";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
                }
            }
            if (where != "")
            {
                sorgu += where.Replace("where", "and");
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
            //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
            daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
            //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
            daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
            daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
            daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
            daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında ihbar raporu sorguladı", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_RAPOR2(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string where)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct I_ONCELIKLI,I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   
T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL  ),cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=i.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') ), i.I_ID,I_TARIH,I_KAYNAK,I_TELEFON,i.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,i.I_KULLANICI,OL.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,I_CADDE,I_IHBARTUR,
cmpt_count=(select count(I_TELEFON) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND  ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 group by I_TELEFON)    FROM I_IHBAR as i left join I_IHBARDETAY as d on i.I_ID=d.ID_IHID left join I_KANAL k on k.KNL_KODU=d.I_KANAL left join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  left join I_MAHALLE M ON i.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID left JOIN I_LOG L On i.I_ID=L.L_IHBARID   where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2";
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON like '" + ihbarcitel + "%'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM like '" + ihbarciadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE IN (" + mahalle + ")";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE like '%" + cadde + "%'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA=@I_PLAKA";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR IN (" + ustolay + ")";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU IN (" + altolay + ")";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  i.I_DURUM IN (" + aramadurum + ")";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I_ONCELIKLI = '" + diger + "'";
                }
            }
            if (where != "")
            {
                sorgu += where.Replace("where", "and");
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
            //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
            daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
            //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
            daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
            daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
            daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
            daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında ihbar raporu sorguladı", "I_IHBARLOG", ref durum);
            return dtt;
            //öncelikli,log,
        }
        public static System.Data.DataTable S_GETIHBAR_RAPOR2_LIKE(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string where,string ICERIK)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   
T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL  ),cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=i.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') ), i.I_ID,I_TARIH,I_KAYNAK,I_TELEFON,i.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,i.I_KULLANICI,OL.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,I_CADDE,I_IHBARTUR,
cmpt_count=(select count(I_TELEFON) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND  ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 group by I_TELEFON)    FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  left join I_MAHALLE M ON i.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID   where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND (I_IHBARBILGISI like '%" + ICERIK + "%' or I_ADRES like '%" + ICERIK + "%')";
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON like '" + ihbarcitel + "%'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM like '" + ihbarciadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE IN (" + mahalle + ")";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE like '%" + cadde + "%'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA=@I_PLAKA";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR IN (" + ustolay + ")";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU IN (" + altolay + ")";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  i.I_DURUM IN (" + aramadurum + ")";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
                }
            }
            if (where != "")
            {
                sorgu += where.Replace("where", "and");
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
            //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
            daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
            //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
            daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
            daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
            daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
            daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında ihbar raporu sorguladı", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_RAPORWHERE(string WHERE)
        {
            string INsorgu = "";
            if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            {
                INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            }
            else
            {
                INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            }
         
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select MAX(L_ISLEM) from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT) ) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11') ),I.I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,D.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID left join I_IHBARTAKIP T ON T.I_IHBARID=I.I_ID  ";
            if (WHERE != "")
            {
                sorgu += WHERE;
            }
         
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG("İhbar listesinden ihbar rapor seçeneklerini kullandı", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_RAPORWHERE2(string WHERE, string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I.I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID left join I_IHBARTAKIP T ON T.I_IHBARID=I.I_ID  ";
            if (WHERE != "")
            {
                sorgu += WHERE;
            }
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON like '" + ihbarcitel + "%'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM like '" + ihbarciadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE IN (" + mahalle + ")";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE like '%" + cadde + "%'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA='" + plaka + "'";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR IN (" + ustolay + ")";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU IN (" + altolay + ")";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  I.I_DURUM IN (" + aramadurum + ")";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
                }
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında İhbar listesinden ihbar rapor seçeneklerini kullandı", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_RAPOR_KULLANICI(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string where)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select max(L_ISLEM) from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2 and (D.I_KANAL IN ('" + HttpContext.Current.Session["SS_KANAL"].ToString() + "') or i.I_KULLANICI='" + HttpContext.Current.Session["SS_KANAL"].ToString() + "')";
            if (ihbarcitel != "")
            {
                sorgu += " and I_TELEFON like '" + ihbarcitel + "%'";
            }
            if (ihbarciadi != "")
            {
                sorgu += " and I_ISIMSOYISIM like '" + ihbarciadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE=@I_ILCE";
            }
            if (mahalle != "")
            {
                sorgu += " and I_MAHALLE like '" + mahalle + "%'";
            }
            if (cadde != "")
            {
                sorgu += " and I_CADDE like'" + cadde + "%'";
            }
            if (plaka != "")
            {
                sorgu += " and I_PLAKA=@I_PLAKA";
            }
            if (ustolay != "")
            {
                sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
            }
            if (altolay != "")
            {
                sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
            }
            if (kanal != "")
            {
                sorgu += " and D.I_KANAL IN (" + kanal + ")";
            }
            if (log != "")
            {
                sorgu += " and L.L_ISLEM IN (" + log + ")";
            }
            if (aramadurum != "")
            {
                sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
            }
            if (diger != "")
            {
                if (diger != "True")
                {
                    if (diger == "1")
                    {

                        sorgu += " and  D.I_ITF = 'True'";
                    }
                    if (diger == "2")
                    {
                        sorgu += " and  D.I_AMB = 'True'";
                    }
                }
                else
                {
                    sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
                }
            }
            if (where != "")
            {
                sorgu += where.Replace("where", "and");
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
            //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
            //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
            //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
            daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
            daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
            daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
            daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
            daa.SelectCommand.Parameters.AddWithValue("@KULLANICI", HttpContext.Current.Session["SS_KANAL"].ToString());
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(tarih1 + " " + tarih2 + " aralığında ihbar raporu sorguladı", "I_IHBARLOG", ref durum);
            return dtt;

        }

        public void Dispose()
        { 
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
