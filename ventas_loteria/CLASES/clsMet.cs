using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ventas_loteria
{
    class clsMet
    {
        public static string cn;
        public static string idPerf;
        public static string nombUsu;
        public static string idUsu;
        public static string idGrup;
        public static int monto_multiplo_jug;
        public static int monto_min_jug;
        public static int monto_max_jug;
        public static int montMaxTck;
        public static int mMaxTrip;
        public static int monto_Xunidad;
        public static int cantDiaCadTck;
        public static int cantSortTrip;
        public static string ntMsjTck;
        public static int idCn;
        public static string version_pro = "";
        public static string nomb_perfil;
        public static string clave_ed = "UHSW]s$Q#DiFfV3YB;NzB1yETu2U&5KZ";
        public static string menbrete_info;
        public static string nomb_imp = "";
        public static string ancho_ticket = "";
        public static string num_letra = "";
        public static string msj_error_cn = "";
        public static string NombDivisa = "";
        public static string FechaActual = "";
        public static Boolean verfAct = false;

        public static MySqlConnection cn_bd = new MySqlConnection();
        public static void Desconectar() { if (cn_bd.State == ConnectionState.Open) cn_bd.Close(); }
        public static void conectar()
        {
            try
            {
                if (cn_bd.State == ConnectionState.Closed)
                {
                    cn_bd.ConnectionString = cn; cn_bd.Open();
                    idCn = 1;
                }
            }
            catch (Exception ex)
            {
                msj_error_cn = ex.Message;
                idCn = 0;
            }
        }

        public static string cifrar(string cadena, string key)
        {
            //MessageBox.Show(cadena + "           --p--           " + key);
            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        public static string descifrar(string cadena, string key)
        {

            byte[] llave;
            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            return cadena_descifrada; // Devolvemos la cadena
        }
        public static string proc_rif(string prm_rif)
        {
            int cant_dig_rif = prm_rif.Length;
            string letra_rif = prm_rif.Substring(0, 1);
            string rif = prm_rif.Substring(1, cant_dig_rif - 2);
            string ult_dig_rif = prm_rif.Substring(cant_dig_rif - 1, 1);

            prm_rif = letra_rif + "-" + rif + "-" + ult_dig_rif;
            return prm_rif;
        }

        public static Boolean verf_email(String prm_email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(prm_email, expresion))
            {
                if (Regex.Replace(prm_email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public string SP_verf_exist_email(string prm_email)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_datos_recordar_clave";
                        cmd.Parameters.AddWithValue("prm_email", prm_email);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["nick"].ToString() + "|" + dr["clave"].ToString() + "|" +
                                            dr["nomb_preg_seguridad"].ToString() + "|" +
                                           dr["resp_seg"].ToString() + "|" + dr["email"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string verfLogUsu(string prmUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPverfLog";
                        cmd.Parameters.AddWithValue("prmUsu", prmUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["nick"].ToString() + "?" + 
                                 dr["clave"].ToString() + "?" +
                                 dr["id_status"].ToString() + "?" + 
                                 dr["id_perfil"].ToString() + "?" +
                                 dr["id_usuario"].ToString() + "?" + 
                                 dr["nomb_perfil"].ToString() + "?" +
                                 dr["id_grupo"].ToString() + "?" + 
                                 dr["monto_max_jug"].ToString() + "?" +
                                 dr["mMaxTrip"].ToString() + "?" +
                                 dr["monto_max_ticket"].ToString() + "?" + 
                                 dr["monto_Xunidad"].ToString() + "?" +
                                 dr["monto_multiplo_jug"].ToString() + "?" + 
                                 dr["monto_min_jug"].ToString() + "?" +
                                 dr["nomb_impresora"].ToString() + "?" + 
                                 dr["ancho_ticket"].ToString() + "?" +
                                 dr["num_letra"].ToString() + "?" + 
                                 dr["nombDivisa"].ToString();

                        }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string[] busPrmGral()
        {
            string[] rsPrmGral = new string[4];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPbusParamGral";
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsPrmGral[0] = dr["cantDiaCadTck"].ToString();
                            rsPrmGral[1] = dr["ntMsjTck"].ToString();
                            rsPrmGral[2] = dr["idTipProcDat"].ToString();
                            rsPrmGral[3] = dr["cantSortTrip"].ToString();
                        }
                        else
                        {
                            rsPrmGral[0] = "";
                            rsPrmGral[1] = "";
                            rsPrmGral[2] = "";
                            rsPrmGral[3] = "";
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
                rsPrmGral[0] = ex.Message;
                rsPrmGral[1] = "";
                rsPrmGral[2] = "";
                rsPrmGral[3] = "";
            }
            return rsPrmGral;
        }

        public string[] verfMacTaq(string prmMac, int prmIdUsuario)
        {
            string[] rsDat = new string[3];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verifica_mac_equipo";
                        cmd.Parameters.AddWithValue("prmMac", prmMac);
                        cmd.Parameters.AddWithValue("prmIdUsuario", prmIdUsuario);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            rsDat[0] = "true";
                            rsDat[1] = dr["idStatus"].ToString();
                            rsDat[2] = dr["idUsuario"].ToString();
                        }
                        else
                        {
                            rsDat[0] = "false";
                            rsDat[1] = "0";
                            rsDat[2] = "0";
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message, "Verifique.");
                rsDat[0] = "false";
                rsDat[1] = "0";
                rsDat[2] = "0";
            }
            return rsDat;
        }

        public string busClavUsu(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verf_cambio_clave";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["clave"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string cambClavUsuario(int prmidUsu, string prmClav)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_act_cambio_clave";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmidUsu);
                        cmd.Parameters.AddWithValue("prm_clave", prmClav);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busGrup(int prmIdUsu, int prmIdPerf,
                                 int prmIdGrup)
        {
            DataTable dt = new DataTable("busGrup");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusGrupConf";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busLetRif()
        {
            DataTable dt = new DataTable("busLetRif");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_letra_rif";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busCodTlf()
        {
            DataTable dt = new DataTable("busCodTlf");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_cod_area_telf";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busStat()
        {
            DataTable dt = new DataTable("busStat");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_status";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busPerf(int prmIdPerf)
        {
            DataTable dt = new DataTable("busPerf");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusPerf";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable bus_grupos_sist_Xfiltro_nomb(string prmNombGrup)
        {
            DataTable dt = new DataTable("bus_grupos_sist_Xfiltro_nomb");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grupos_Xfiltro_nomb";
                        cmd.Parameters.AddWithValue("prm_nomb_grupo", prmNombGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public string grdActGrupos(int prmIdGrup, string prmNombGrup,
                                    string prmRs, string prmRif, 
                                    string prmNroTelf, string prmDir,
                                    string prmEmail, int prmIdStat)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_act_grupos";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_nomb_grupo", prmNombGrup);
                        cmd.Parameters.AddWithValue("prm_razon_social", prmRs);
                        cmd.Parameters.AddWithValue("prm_rif", prmRif);
                        cmd.Parameters.AddWithValue("prm_nro_telef", prmNroTelf);
                        cmd.Parameters.AddWithValue("prm_direccion", prmDir);
                        cmd.Parameters.AddWithValue("prm_email", prmEmail);
                        cmd.Parameters.AddWithValue("prm_id_status", prmIdStat);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busUsu(int prmIdGrup)
        {
            DataTable dt = new DataTable("busUsu");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_usuarios_grupos";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; }
            return dt;
        }
        public string cantUsuGrup(int prmIdGrup)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_cant_usuario";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["cant_usuarios_grupo"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string grdActUsuarios( int prmIdGrup, int prmIdUsu, 
                                      int prmIdDiv, string prmNombUsu,
                                      string prmClav, string prmEmail, 
                                      int prmIdStat, int prmIdPerf, 
                                      int prmIdPregSeg, string prmRespSeg,
                                      string prmPorcTaq, string prmPorcCasa, 
                                      string prmPorcSist, int prmMontoMaxJug, 
                                      int prmMontoMaxTck, int prmMontoxUn,
                                      int prmIdTipCuad, int prmMultJug,
                                      int prmMinJug, int prmUnBas, 
                                      int prmCierreSort, string prmMac)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_act_usuarios";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdDivisa", prmIdDiv);
                        cmd.Parameters.AddWithValue("prm_nomb_usuario", prmNombUsu);
                        cmd.Parameters.AddWithValue("prm_clave", prmClav);
                        cmd.Parameters.AddWithValue("prm_email", prmEmail);
                        cmd.Parameters.AddWithValue("prm_id_preg_seg", prmIdPregSeg);
                        cmd.Parameters.AddWithValue("prm_resp_seg", prmRespSeg);
                        cmd.Parameters.AddWithValue("prm_id_status", prmIdStat);
                        cmd.Parameters.AddWithValue("prm_id_perfil", prmIdPerf);
                        cmd.Parameters.AddWithValue("prm_porc_taquilla", prmPorcTaq);
                        cmd.Parameters.AddWithValue("prm_porc_casa", prmPorcCasa);
                        cmd.Parameters.AddWithValue("prm_porc_sist", prmPorcSist);
                        cmd.Parameters.AddWithValue("prm_monto_max_jug", prmMontoMaxJug);
                        cmd.Parameters.AddWithValue("prm_monto_max_ticket", prmMontoMaxTck);
                        cmd.Parameters.AddWithValue("prm_monto_xUnidad", prmMontoxUn);
                        cmd.Parameters.AddWithValue("prm_id_tipo_cuadre", prmIdTipCuad);
                        cmd.Parameters.AddWithValue("prm_multiplo_jug", prmMultJug);
                        cmd.Parameters.AddWithValue("prm_minimo_jug", prmMinJug);
                        cmd.Parameters.AddWithValue("prm_unidad_base", prmUnBas);
                        cmd.Parameters.AddWithValue("prm_cierre_sorteo", prmCierreSort);
                        cmd.Parameters.AddWithValue("prmMac", prmMac);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busPregSeg()
        {
            DataTable dt = new DataTable("busPregSeg");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_preg_seguridad";
                        da = new MySqlDataAdapter(cmd);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busStatMac()
        {
            DataTable dt = new DataTable("busStatMac");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_status_mac";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable bus_status_mac_filtro()
        {
            DataTable dt = new DataTable("bus_status_mac_filtro");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_status_mac_filtro";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busMac(int prmIdPerf, int prmIdGrup)
        {
            DataTable dt = new DataTable("busMac");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mac_adrress";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa" + ex.Message); }
            return dt;
        }

        public DataTable busTipCuad()
        {
            DataTable dt = new DataTable("busTipCuad");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_tipo_cuadre";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busDiv()
        {
            DataTable dt = new DataTable("busDiv");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusDivisa";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busMacXfiltro(string prmDirMac)
        {
            DataTable dt = new DataTable("busMacXfiltro");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mac_Xfiltro";
                        cmd.Parameters.AddWithValue("prm_dir_mac", prmDirMac);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busMacXfiltStat(int prmIdStat)
        {
            DataTable dt = new DataTable("busMacXfiltStat");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mac_Xfiltro_status";
                        cmd.Parameters.AddWithValue("prm_id_status", prmIdStat);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable bus_mac_nuevas()
        {
            DataTable dt = new DataTable("bus_mac_nuevas");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mac_address_nuevas";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string grd_asocia_mac(int prmIdGrupUsu, int prmIdUsu,
                                     int prmIdMacNuev)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_act_mac_nueva";
                        cmd.Parameters.AddWithValue("prm_id_grupo_usuario", prmIdGrupUsu);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_id_mac_nueva", prmIdMacNuev);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }  
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string actStatMac(int prm_id_mac, int prm_id_status)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_act_status_mac";
                        cmd.Parameters.AddWithValue("prm_id_mac", prm_id_mac);
                        cmd.Parameters.AddWithValue("prm_id_status", prm_id_status);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busLotProcRs()
        {
            DataTable dt = new DataTable("busLotProcRs");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_sorteos_proc_result";
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            return dt;
        }
        public DataTable busTipProc()
        {
            DataTable dt = new DataTable("busTipProc");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_bus_tipo_proc_datos";
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busTipTck()
        {
            DataTable dt = new DataTable("busTipTck");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListTipTck";
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busLot(int prmIdUsu)
        {
            DataTable dt = new DataTable("busLot");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusSort";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busNombProd()
        {
            DataTable dt = new DataTable("busNombProd");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusNombProd";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable bus_sorteos(int prmIdLot)
        {
            DataTable dt = new DataTable("bus_sorteos");
            MySqlDataAdapter da;
            try
            {

                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_sorteos";
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string grd_jugada(int prmIdGrup, int prmIdUsu,
                                int prmIdLot, int prmIdSort,
                                string prmCod, string prmMont,
                                string prmIdTmpJug)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_jugada_seleccionada";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        cmd.Parameters.AddWithValue("prm_id_sorteos", prmIdSort);
                        cmd.Parameters.AddWithValue("prm_codigo", prmCod);
                        cmd.Parameters.AddWithValue("prm_monto", prmMont);
                        cmd.Parameters.AddWithValue("prm_id_temp_jug", prmIdTmpJug);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busJug(string prmNroTck)
        {
            DataTable dt = new DataTable("busJugs");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_jugadas";
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null;}
            return dt;
        }

        public string verf_jugadas_cerrada(int prmIdUsu, int prmIdLot,
                                              int prmIdSort)
        {
            string rsDat = "";
            try
            {
                 using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verf_jug_sorteo_cerrado";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        cmd.Parameters.AddWithValue("prm_id_sorteo", prmIdSort);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string dlt_jugada(int prmIdTmpJug, int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_borra_jugada";
                        cmd.Parameters.AddWithValue("prm_id_tmp_jugada", prmIdTmpJug);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable bus_producto(int prmIdLot)
        {
            DataTable dt = new DataTable("bus_producto");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_producto";
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string verfHoraServ(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_bus_hora_servidor";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["fechaHoraServ"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string bus_total_jug(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_monto_total_jug";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["monto_jug"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string[] busFechHoraServ()
        {
            string[] rsDat = new string[2];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_busFechaHoraServ";
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        rsDat[0] = dr["fechaAct"].ToString();
                        rsDat[1] = dr["horaAct"].ToString();
                        dr.Close();
                    }
                }  
            }
            catch (Exception ex) { rsDat[0] = "0"; rsDat[1] = ex.Message; }
            return rsDat;
        }
        public string verf_jug_imp_ticket(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_ver_cant_jug_imp_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["cant_jug"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string busInfTicket(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPinfReimpTck";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["prmCantTck"].ToString() + "?" + 
                                dr["prmPermitReimp"].ToString() + "?" +
                                dr["prmCantMinReimp"].ToString() + "?" + 
                                dr["prmNroTck"].ToString() + "?" +
                                dr["prmNroSer"].ToString() + "?" + 
                                dr["prmFech"].ToString() + "?" +
                                dr["prmHor"].ToString() + "?" + 
                                dr["prmMtck"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string grd_ticket_usuario(int prmIdGrup, int prmIdUsu,
                                        string prmMontTck)
        {
            string rsDat = "";
            string msjInf = "";
            Boolean rsProc = false;
            MySqlTransaction myTrans = null;

            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        myTrans = cnBd.BeginTransaction();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_ticket";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_monto_ticket", prmMontTck);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsProc = true;
                            rsDat = rsProc + "?" +
                                dr["prm_cont_ticket"].ToString() + "?" +
                                dr["prm_nro_Serial"].ToString() + "?" +
                                dr["fecha_ticket"].ToString() + "?" +
                                dr["hora_ticket"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                        myTrans.Commit();
                    }
                }
                
            }
            catch (Exception ex)
            {
                rsDat = rsProc + "?" + ex.Message;
                try { if (clsMet.cn_bd.State == ConnectionState.Open) { myTrans.Rollback(); } }
                catch (MySqlException error)
                {
                    if (myTrans.Connection != null)
                    {
                        msjInf = "Una excepción de tipo \"" + error.GetType() + " \"";
                        msjInf += " se encontró al intentar revertir la transacción.";
                        MessageBox.Show(msjInf, "Transacción Fallida...");
                    }
                }

                msjInf = "Una excepción de tipo: \"" + ex.GetType() + "\"";
                msjInf += "\n se encontró al insertar los datos. \n Tome nota del";
                msjInf += " siguiente error: \"" + ex.Message + "\"";
                MessageBox.Show(msjInf, "Transacción Fallida...");
            }
            return rsDat;
        }
        public string verf_exits_ticket(long prmNroTck, long prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verf_exits_ticket";
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        cmd.Parameters.AddWithValue("prm_nro_serial", prmNroSer);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["cant_ticket"].ToString() + "?" + 
                                dr["fecha_reg"].ToString() + "?" +
                                dr["hora_reg"].ToString();
                        }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string busCuadCajDiario(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPbusCuadCajDia";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["prmTotVent"].ToString() + "?" + 
                                dr["prmTotVentAn"].ToString() + "?" + 
                                dr["prmTotVentTrip"].ToString() + "?" + 
                                dr["prmTotPag"].ToString()+ "?" + 
                                dr["prmTotTckAn"].ToString() + "?" +
                                dr["prmTotCaj"].ToString() + "?" +
                                dr["prmUltTck"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string bus_repet_ultimo_ticket(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_repet_ultimo_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["permitir"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string limpia_jug_pend(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_limpia_jug_pend";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string verfStatTck(int prmIdUsu, string prmNroTck,
                                  string prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPVerfStatTck";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        cmd.Parameters.AddWithValue("prmNroSer", prmNroSer);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["idStat"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string actStatTck(int prmIdUsu, string prmNroTck,
                                string prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_act_paga_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        cmd.Parameters.AddWithValue("prm_nro_serial", prmNroSer);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows) { rsDat = dr["monto_pagado"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string verfDetTckAnu(string prmNroTck)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPDetTckAn";
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["rsAnTck"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string verfExitsMostTick(int prmIdUsu, long prmNroTck,
                                                    long prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verf_exists_mostrar_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        cmd.Parameters.AddWithValue("prm_nro_serial", prmNroSer);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["cant_ticket"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string SPMostInfTck(string prmNroTck, string prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPInfTck";
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        cmd.Parameters.AddWithValue("prmNroSer", prmNroSer);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["idTipTck"].ToString() + "?" +
                                dr["nick"].ToString() + "?" + 
                                dr["nombStatTck"].ToString() + "?" + 
                                dr["mTck"].ToString() + "?" +
                                dr["mPag"].ToString() + "?" + 
                                dr["fechReg"].ToString() + "?" + 
                                dr["horaReg"].ToString();
                        }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string SPMostInfTck(string prmNroTck)
        {
            string rsDat = "";
            int prmIdGrup = 0;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        prmIdGrup = Convert.ToInt16(clsMet.idGrup);
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPbusInfTckAn";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["nick"].ToString() + "?" +
                                dr["nombStatTck"].ToString() + "?" + 
                                dr["mTck"].ToString() + "?" + 
                                dr["mPag"].ToString() + "?" + 
                                dr["fechReg"].ToString() + "?" + 
                                dr["horReg"].ToString() + "?" +
                                dr["idStat"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string busMostDetTck(long prmNroTck, long prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPTckDet";
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        string nombLot = "", horaSort = "";
                        string codJug = "", nombProd = "";
                        int idLot = 0, idSort = 0;
                        int contDetJug = 0;
                        double mJug = 0;

                        while (dr.Read())
                        {
                            codJug = dr["codJug"].ToString().Trim();
                            nombProd = dr["nombProd"].ToString().Trim();
                            mJug = Convert.ToDouble(dr["monto"].ToString().Trim());

                            if ((idLot != Convert.ToInt32(dr["idLot"].ToString()))
                                || idSort != Convert.ToInt32(dr["idSort"].ToString()))
                            {

                                nombLot = dr["nombLot"].ToString();
                                horaSort = dr["horaSort"].ToString();
                                rsDat += "-------------------------------------------\n";
                                rsDat += nombLot + "  ";
                                rsDat += Convert.ToDateTime(horaSort).ToString("hh:mm tt").ToUpper();
                                rsDat += "\n\n";
                                contDetJug = 0;
                            }
                            contDetJug++;
                            rsDat += codJug + " " + nombProd.Substring(0, 3);
                            rsDat += " " + mJug.ToString("N2") + "   ";

                            if (contDetJug == 2) { rsDat += "\n"; contDetJug = 0; }
                            idLot = Convert.ToInt32(dr["idLot"].ToString());
                            idSort = Convert.ToInt32(dr["idSort"].ToString());
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public string busMostDetTckTrip(long prmNroTck, long prmNroSer)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPTckDetTrip";
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        string nombLot = "", fechaIni = "";
                        string fechaFin = "", nombProd = "";
                        string  mont = "";
                        int idLot = 0, contDetJug = 0;
                        long mJug = 0;

                        while (dr.Read())
                        {
                            nombLot = dr["nombLot"].ToString().Trim();
                            fechaIni = dr["fechaIni"].ToString().Trim();
                            fechaFin = dr["fechaFin"].ToString().Trim();
                            nombProd = dr["nombProd"].ToString().Trim();
                            mont = dr["mont"].ToString().Trim();

                            //MessageBox.Show(nombLot+" "+ fechaIni + " " + nombProd + " " + mont);

                            //if (idLot != Convert.ToInt32(dr["idLot"].ToString()))
                           // {

                                nombLot ="TRIPLETA: " + dr["nombLot"].ToString();
                                rsDat += "------------------------------------------\n";
                                rsDat += nombLot;
                                rsDat += "\n";
                                rsDat += fechaIni;
                                rsDat += "\n";
                                rsDat += fechaFin;
                                rsDat += "\n";
                                rsDat += nombProd;
                                rsDat += "\n";
                                rsDat += "Monto jugando: ";
                                rsDat += Convert.ToDouble(mont).ToString("N2");
                                rsDat += " "+ clsMet.NombDivisa;
                                rsDat += "\n";
                                rsDat = rsDat.ToUpper();
                               contDetJug = 0;
                            //}
                            contDetJug++;

                            if (contDetJug == 2) { rsDat += "\n"; contDetJug = 0; }
                            idLot = Convert.ToInt32(dr["idLot"].ToString());
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }


        public string SPMostDetTckAn(long prmNroTck)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mostrar_ticket_det_anular";
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        string nombLot = "", horaSort = "";
                        string codJug = "", nombProd = "";
                        int idLot = 0, idSort = 0;
                        long mJug = 0;
                        int contDetJug = 0;

                        while (dr.Read())
                        {
                            codJug = dr["codigo_jugada"].ToString().Trim();
                            nombProd = dr["nomb_product"].ToString().Trim();
                            mJug = Convert.ToInt64(dr["monto"].ToString().Trim());

                            //MessageBox.Show(id_loteria + "---" + Convert.ToInt32(dr["id_loteria"].ToString()));
                            //MessageBox.Show(id_sorteo + "---" + Convert.ToInt32(dr["id_sorteo"].ToString()));

                            if ((idLot != Convert.ToInt32(dr["id_loteria"].ToString())) ||
                                idSort != Convert.ToInt32(dr["id_sorteo"].ToString()))
                            {
                                nombLot = dr["nomb_loteria"].ToString();
                                horaSort = dr["hora_sorteo"].ToString();
                                rsDat += "-------------------------------------\n";
                                rsDat += nombLot + "  ";
                                rsDat += Convert.ToDateTime(horaSort).ToString("hh:mm tt").ToUpper();
                                rsDat += "\n\n";
                                contDetJug = 0;
                            }

                            contDetJug++;
                            rsDat += codJug + " " + nombProd.Substring(0, 3);
                            rsDat += " " + mJug.ToString("N2") + "   ";

                            if (contDetJug == 2) { rsDat += "\n"; contDetJug = 0; }
                            idLot = Convert.ToInt32(dr["id_loteria"].ToString());
                            idSort = Convert.ToInt32(dr["id_sorteo"].ToString());
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable busStatTckFilt()
        {
            DataTable dt = new DataTable("busStatTckFilt");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_status_ticket_filtro";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busMovStatTck(int prmIdUsu)
        {
            DataTable dt = new DataTable("busMovStatTck");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mov_status_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busStatTckXfilt(int prmIdUsu, string prmFechIni,
                                     string prmFechFin, int prmIdStatTck)
        {
            DataTable dt = new DataTable("busStatTckXfilt");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_mov_status_ticket_Xfiltro";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                        cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                        cmd.Parameters.AddWithValue("prm_id_status_ticket", prmIdStatTck);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string busTotVent(int prmIdUsu, string prmFechIni,
                                 string prmFechFin, int prmIdStatTck)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_mov_ventas";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                        cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                        cmd.Parameters.AddWithValue("prm_id_status_ticket", prmIdStatTck);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["cant_ticket"].ToString() + "? " + 
                                dr["monto_total_entrada"].ToString() + "? " + 
                                dr["monto_total_salida"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable busTotVentas(int prmIdUsu)
        {
            DataTable dt = new DataTable("busTVentas");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_taq";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busTotVentasFiltro(int prmIdUsu, string prmFechIni,
                                            string prmFechFin)
        {
            DataTable dt = new DataTable("bus_totales_venta_Xfiltro");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_taq_Xfiltro";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                        cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string busTotVentas(int prmIdUsu, string prmFechIni,
                                   string prmFechFin)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_ventas_taq";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                        cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["monto_entrada"].ToString() + "? " + 
                                dr["monto_salida"].ToString() + "? " + 
                                dr["monto_taq"].ToString() + "? " + 
                                dr["monto_utilidad"].ToString();
                        }

                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                rsDat = ex.Message;
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
            }
            return rsDat;
        }
        public DataTable busJugProcRs(int prmIdPerf, int prmIdGrup, 
                                    string prmFech)
        {
            DataTable dt = new DataTable("busJugProcRs");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusJugProcRs";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmFech", prmFech);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (MySqlException ex) { dt = null; MessageBox.Show("busJugProcRs: " + ex.Message, "busJugProcRs"); }
            return dt;
        }
        public DataTable busJugProcRsMan(int prmIdPerf, int prmIdGrup, 
                                        int prmIdSort,string prmFech)
        {
            DataTable dt = new DataTable("busJugProcRsMan");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusJugProcRsMan";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        cmd.Parameters.AddWithValue("prmFech", prmFech);

                        //MessageBox.Show(prmIdPerf+"  "+ prmIdGrup + "  " + prmIdSort + "  " + prmFech);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (MySqlException ex) { dt = null; MessageBox.Show("busJugProcRs: " + ex.Message); }
            return dt;
        }

        public DataTable listProdBloq(int prmIdGrup, int prmIdLot)
        {
            DataTable dt = new DataTable("listProdBloq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListProdBloq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable listProdBloqFilt(int prmIdGrup, int prmIdLot, 
                                          int prmIdSort)
        {
            DataTable dt = new DataTable("listProdBloqFilt");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListProdBloqFilt";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busContVentTaq(int prmIdLot)
        {
            DataTable dt = new DataTable("busContVentTaq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spContVentTaq";
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busJugPendProc(int prmIdPerf, int prmIdGrup)
        {
            DataTable dt = new DataTable("busJugPendProc");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusJugPendProc";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busTipJugPendProc(int prmIdPerf, int prmIdGrup,
                                            int prmIdTipTck)
        {
            DataTable dt = new DataTable("busJugPendProc");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusTipJugPendProc";
                        cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdTipTck", prmIdTipTck);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable bus_sorteo_proc_result(int prmIdLot)
        {

            DataTable dt = new DataTable("bus_sorteo_proc_result");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_sorteos_proc_result";
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string actStatProd(int prmIdGrup, int prmIdUsu,
                                    int prmIdLot, int prmIdSort,
                                    string prmCodProd, int prmIdStat)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spActStatProd";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        cmd.Parameters.AddWithValue("prmCodProd", prmCodProd);
                        cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                        rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string actStatProdTod(int prmIdGrup, int prmIdLot,
                                   string prmCodProd, int prmIdStat)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spActStatProdTod";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmCodProd", prmCodProd);
                        cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                        rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public string grdActRstLot(int prmIdLot, int prmIdSort,
        string prmResultLot, string prmFechLot)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_act_result_lot";
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        cmd.Parameters.AddWithValue("prm_id_sorteos", prmIdSort);
                        cmd.Parameters.AddWithValue("prm_result_lot", prmResultLot);
                        cmd.Parameters.AddWithValue("prm_fecha_loteria", prmFechLot);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (MySqlException ex) { rsDat = ex.Message; MessageBox.Show(rsDat, "grdActRstLot"); }
            return rsDat;
        }
        public string busProcRsLot(int prmIdDetJug, int prmIdLot,
                                   int prmIdSort, int prmIdUsu, 
                                   int prmIdStatTck, string prmNroTck, 
                                   string prmMjugTck, string prmCodJugTck, 
                                   string prmRstLot)
        {
                                                                        
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPactRsLot";
                        cmd.Parameters.AddWithValue("prmIdDetJug", prmIdDetJug);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdStatTck", prmIdStatTck);
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        cmd.Parameters.AddWithValue("prmMjugTck", prmMjugTck);
                        cmd.Parameters.AddWithValue("prmCodJugTck", prmCodJugTck);
                        cmd.Parameters.AddWithValue("prmRsLot", prmRstLot);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows) { rsDat = dr["statTck"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                        Console.WriteLine("busProcRsLot dr:" + dr.IsClosed.ToString());
                    }
                }
               // MessageBox.Show(prmIdDetJug + " " + prmIdLot + " " + prmIdSort + " " + prmRstLot);

            }
            catch (MySqlException ex) { rsDat = ex.Message;  }
            catch (Exception ex) { rsDat = ex.Message;  }
            return rsDat;
        }
        public string busProcRsLotTrip(int prmIdDetJug, int prmIdLot, 
                                       int prmIdUsu, int prmIdStatTck,
                                       string  prmNroTck, string prmMjugTck,
                                       string prmCodJugTck,string prmRstLot)

        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                       // MessageBox.Show(prmIdUsu+" | "+ prmIdStatTck + " | " + prmNroTck + " | " + prmMjugTck + " | " + prmCodJugTck);
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPactRsLotTrip";
                        cmd.Parameters.AddWithValue("prmIdDetJug", prmIdDetJug);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdStatTck", prmIdStatTck);
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        cmd.Parameters.AddWithValue("prmMjugTck", prmMjugTck);
                        cmd.Parameters.AddWithValue("prmCodJugTck", prmCodJugTck);
                        cmd.Parameters.AddWithValue("prmRsLot", prmRstLot);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows) { rsDat = dr["statTck"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }

            }
            catch (MySqlException ex) { rsDat = ex.Message; }
            catch (Exception ex) { rsDat = ex.Message;  }
            return rsDat;
        }
        public DataTable bus_cuadre_taq(int prmIdGrup, int prmIdUsu)
        {
            DataTable dt = new DataTable("bus_cuadre_taq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_grupo_taq";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busGrupTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busGrupTaq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPbusGrupTaq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable BusTaqContVent(int prmIdGrup)
        {
            DataTable dt = new DataTable("BusTaqContVent");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusTaqContVent";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            return dt;
        }
        public DataTable BusGrup()
        {
            DataTable dt = new DataTable("BusGrup");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusGrup";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            return dt;
        }
        public DataTable busVentGrup(int prmIdgrup, int prmIdDiv,
                                    string prmFechIni, string prmFechFin)
        {
            DataTable dt = new DataTable("busVentTodGrup");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusTotGrup";
                        cmd.Parameters.AddWithValue("prmIdgrup", prmIdgrup);
                        cmd.Parameters.AddWithValue("prmIdDiv", prmIdDiv);
                        cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                        cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busVentGrupTod(int prmIdgrup, int prmIdDiv,
                                        string prmFechIni, string prmFechFin)
        {
            DataTable dt = new DataTable("busVentTodGrup");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusTotGrupTod";
                        cmd.Parameters.AddWithValue("prmIdgrup", prmIdgrup);
                        cmd.Parameters.AddWithValue("prmIdDiv", prmIdDiv);
                        cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                        cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busTotCuadGrupTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busTotCuadGrupTaq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_grupo_taq";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busTotCuadGrupTaqFilt(int prmIdGrup, int prmIdUsu,
                                               string prmFechIni, string prmFechFin)
        {
            DataTable dt = new DataTable("busTotCuadreGrupoTaqFiltro");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_totales_grupo_taq_Xfiltro";
                        cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                        cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busTotGrupoTaqXDiv(int prmIdGrup, int prmIdUsu,
                                               int prmIdDiv, string prmFechaIni,
                                               string prmFechaFin)
        {
            DataTable dt = new DataTable("busTotGrupoTaqXDiv");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spBusTotGrupoTaqXDivisa";
                        cmd.Parameters.AddWithValue("prmIdGrupo", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdUsuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdDivisa", prmIdDiv);
                        cmd.Parameters.AddWithValue("prmFechaIni", prmFechaIni);
                        cmd.Parameters.AddWithValue("prmFechaFin", prmFechaFin);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public string busConfImp(int prmIdUsu)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_config_impresora";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat = dr["nomb_impresora"].ToString() + "?" +
                                dr["ancho_ticket"].ToString() + "?" +
                                dr["num_letra"].ToString();

                        }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }  
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable busAnchTck()
        {
            DataTable dt = new DataTable("busAnchTck");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_ancho_ticket";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable busNumLet()
        {
            DataTable dt = new DataTable("busNumLet");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_num_letra";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string actGrdConfImp(int prmIdUsu, string prmNombImp,
                      string prmAnchTck, string prmNumLet)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_grd_act_config_imp";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_nomb_imp", prmNombImp);
                        cmd.Parameters.AddWithValue("prm_ancho_ticket", prmAnchTck);
                        cmd.Parameters.AddWithValue("prm_num_letra", prmNumLet);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable busResultLot()
        {
            DataTable dt = new DataTable("busResultLot");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_result_lot";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busLotRs()
        {
            DataTable dt = new DataTable("busLotRs");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_lot_result";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busResultLotfilt(int prmIdLot, string prmFech)
        {
            DataTable dt = new DataTable("busResultLotfilt");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_result_lot_Xfiltro";
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        cmd.Parameters.AddWithValue("prm_fecha", prmFech);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busGrupTod()
        {
            DataTable dt = new DataTable("busGrupTod");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusGrupTod";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string verf_grd_repet_ticket(int prmIdUsu, string prmNroTck)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_verf_exist_repet_ticket";
                        cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) { rsDat = dr["exits_ticket"].ToString(); }
                        else { rsDat = ""; }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }


        public DataTable repet_jugada_ticket(string prmNroTck, int prmIdLot,
                                            int prmIdSort, string prmNombLot,
                                            string prmHorSort, string prmAbLot)
        {
            DataTable dt = new DataTable("repet_jugada_ticket");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_grd_det_ticket";
                        cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                        cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                        cmd.Parameters.AddWithValue("prm_id_sorteo", prmIdSort);
                        cmd.Parameters.AddWithValue("prm_nomb_loteria", prmNombLot);
                        cmd.Parameters.AddWithValue("prm_hora_sorteo", prmHorSort);
                        cmd.Parameters.AddWithValue("prm_abrev_loteria", prmAbLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string anTck(string prmNroTck)
        {
            string rsDat = "";
            int prmIdGrup = 0;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        prmIdGrup = Convert.ToInt16(clsMet.idGrup);
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPAnTckAdm";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                        rsDat = Convert.ToString(cmd.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable busJugTaq(int prmIdLot, int prmIdSort,
                                    int prmIdTaq, string prmFech)
        {
            DataTable dt = new DataTable("busJugTaq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusJugTaq";
                        cmd.Parameters.AddWithValue("prmIdGrup", clsMet.idGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        cmd.Parameters.AddWithValue("prmIdTaq", prmIdTaq);
                        cmd.Parameters.AddWithValue("prmFech", prmFech);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busLimTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busLimTaq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListLimTaq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public string actLimTaq(int prmIdGrup, int prmIdTaq,
                                string prmMmaxAn)
        {

            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spActLimTaq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdTaq", prmIdTaq);
                        cmd.Parameters.AddWithValue("prmMmaxAn", prmMmaxAn);
                        rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable listLotTod(int prmIdUsu)
        {
            DataTable dt = new DataTable("listLotTod");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListLotTod";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable listLotTodGrup(int prmIdGrup)
        {
            DataTable dt = new DataTable("listLotTodGrup");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListLotTodGrup";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable listLot(int prmIdUsu)
        {
            DataTable dt = new DataTable("listLot");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListLotTod";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        using (da = new MySqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public string[] VerfVentTaq(int prmIdGrup, int prmIdUsu, int prmIdLot,
                            string prmFechIni, string prmFechFin)
        {
            string[] rsDat = new string[14];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spVerfVentTaq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                        cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat[0] = "1";
                            rsDat[1] = "";
                            rsDat[2] = dr["prmMVent"].ToString();
                            rsDat[3] = dr["prmMVentAn"].ToString();
                            rsDat[4] = dr["prmMVentTrip"].ToString();
                            rsDat[5] = dr["prmMPre"].ToString();
                            rsDat[6] = dr["prmMPreAn"].ToString();
                            rsDat[7] = dr["prmMPreTrip"].ToString();
                            rsDat[8] = dr["prmMAn"].ToString();
                            rsDat[9] = dr["prmMAnAn"].ToString();
                            rsDat[10] = dr["prmMAnTrip"].ToString();
                            rsDat[11] = dr["prmMUt"].ToString();
                            rsDat[12] = dr["prmMUtAn"].ToString();
                            rsDat[13] = dr["prmMUtTrip"].ToString();
                        }
                        dr.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                rsDat[0] = "0";
                rsDat[1] = ex.Message;
                rsDat[2] = "";
                rsDat[3] = "";
                rsDat[4] = "";
                rsDat[5] = "";
                rsDat[6] = "";
                rsDat[7] = "";
                rsDat[8] = "";
                rsDat[9] = "";
                rsDat[10] = "";
                rsDat[11] = "";
                rsDat[12] = "";
                rsDat[13] = "";
            }
            return rsDat;
        }

        public string[] VerfVentLot(int prmIdGrup, int prmIdUsu, int prmIdLot,
                                    string prmFechIni,string prmFechFin)
        {
            string[] rsDat = new string[14];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spVerfVentLot";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                        cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows) 
                        {
                            rsDat[0] = "1";
                            rsDat[1] = "";
                            rsDat[2] = dr["prmMVent"].ToString();
                            rsDat[3] = dr["prmMVentAn"].ToString();
                            rsDat[4] = dr["prmMVentTrip"].ToString();
                            rsDat[5] = dr["prmMPre"].ToString();
                            rsDat[6] = dr["prmMPreAn"].ToString();
                            rsDat[7] = dr["prmMPreTrip"].ToString();
                            rsDat[8] = dr["prmMAn"].ToString();
                            rsDat[9] = dr["prmMAnAn"].ToString();
                            rsDat[10] = dr["prmMAnTrip"].ToString();
                            rsDat[11] = dr["prmMUt"].ToString();
                            rsDat[12] = dr["prmMUtAn"].ToString();
                            rsDat[13] = dr["prmMUtTrip"].ToString();
                        }
                        dr.Close();

                    }
                }
            }
            catch (Exception ex)
            {                        
                rsDat[0] = "0";
                rsDat[1] = ex.Message;
                rsDat[2] = "";
                rsDat[3] = "";
                rsDat[4] = "";
                rsDat[5] = "";
                rsDat[6] = "";
                rsDat[7] = "";
                rsDat[8] = "";
                rsDat[9] = "";
            }
            return rsDat;
        }
        public DataTable listLotContVent(int prmIdUsu)
        {
            DataTable dt = new DataTable("listLotContVent");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "splistLotContVent";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable listSortTod(int prmIdLot)
        {
            DataTable dt = new DataTable("listSortTod");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListSortTod";
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable listSortContVentTod(int prmIdLot)
        {
            DataTable dt = new DataTable("listSortContVentTod");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListSortContVentTod";
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable listSortVentTod(int prmIdUsu, int prmIdLot)
        {
            DataTable dt = new DataTable("listSortVentTod");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListSortVentTod";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }

        public string actStatSort(int prmIdGrup, int prmIdUsu,
                                  int prmIdLot, int prmIdSort,
                                  int prmIdStat)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spActStatSort";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                        rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }
        public DataTable listSortBloq(int prmIdGrup, int prmIdLot)
        {
            DataTable dt = new DataTable("listSortBloq");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListSortBloq";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable listProdSortFilt(int prmIdGrup, int prmIdLot, 
                                          int prmIdSort)
        {
            DataTable dt = new DataTable("listProdBloqFilt");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListSortBloqFilt";
                        cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                        cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                        cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busLotTrip(int prmIdUsu)
        {
            DataTable dt = new DataTable("busLotTrip");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPbusLotTrip";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public DataTable busBloqLot(int prmIdUsu)
        {
            DataTable dt = new DataTable("busBloqLot");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spListLotUsu";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            return dt;
        }
        public string actStatLot(int prmIdBloqLot, int prmIdStat, 
                               string prmMontBs, string prmMontUsd)
        {
            string rsDat = "";
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spActStatLot";
                        cmd.Parameters.AddWithValue("prmIdBloqLot", prmIdBloqLot);
                        cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                        cmd.Parameters.AddWithValue("prmMontBs", prmMontBs);
                        cmd.Parameters.AddWithValue("prmMontUsd", prmMontUsd);
                        rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
                    }
                }
            }
            catch (Exception ex) { rsDat = ex.Message; }
            return rsDat;
        }

        public DataTable BusStat()
        {
            DataTable dt = new DataTable("BusStat");
            MySqlDataAdapter da;
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_bus_status";
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            return dt;
        }

        public string formatMonto(string prmCad)
        {
            string resta = "", rsForm = "";
            try
            {
                if (prmCad.Contains("-"))
                {
                    resta = prmCad.Substring(0, 1);
                    prmCad = prmCad.Replace("-", "");
                }

                if (prmCad.Length == 1) { rsForm = "0,0" + prmCad; }
                else if (prmCad.Length == 2) { rsForm = "0," + prmCad; }
                else if ((prmCad.Length >= 3) && (prmCad.Length <= 5))
                {
                    rsForm = prmCad.Substring(0, prmCad.Length - 2);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }
                else if ((prmCad.Length == 6))
                {
                    rsForm = prmCad.Substring(0, 1);
                    rsForm += "." + prmCad.Substring(1, prmCad.Length - 3);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }
                else if ((prmCad.Length == 7))
                {
                    rsForm = prmCad.Substring(0, 2);
                    rsForm += "." + prmCad.Substring(2, prmCad.Length - 4);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }
                else if ((prmCad.Length == 8))
                {
                    rsForm = prmCad.Substring(0, 3);
                    rsForm += "." + prmCad.Substring(3, prmCad.Length - 5);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }
                else if ((prmCad.Length == 9))
                {
                    rsForm = prmCad.Substring(0, 1);
                    rsForm += "." + prmCad.Substring(1, 3);
                    rsForm += "." + prmCad.Substring(4, prmCad.Length - 6);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }
                else if ((prmCad.Length == 10))
                {
                    rsForm = prmCad.Substring(0, 2);
                    rsForm += "." + prmCad.Substring(2, 3);
                    rsForm += "." + prmCad.Substring(5, prmCad.Length - 7);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }

                else if ((prmCad.Length == 11))
                {
                    rsForm = prmCad.Substring(0, 3);
                    rsForm += "." + prmCad.Substring(3, 3);
                    rsForm += "." + prmCad.Substring(6, 3);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }

                else if ((prmCad.Length == 12))
                {
                    rsForm = prmCad.Substring(0, 1);
                    rsForm += "." + prmCad.Substring(1, 3);
                    rsForm += "." + prmCad.Substring(4, 3);
                    rsForm += "." + prmCad.Substring(7, 3);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }

                else if ((prmCad.Length == 13))
                {
                    rsForm = prmCad.Substring(0, 2);
                    rsForm += "." + prmCad.Substring(2, 3);
                    rsForm += "." + prmCad.Substring(5, 3);
                    rsForm += "." + prmCad.Substring(8, 3);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }

                else if ((prmCad.Length == 14))
                {
                    rsForm = prmCad.Substring(0, 3);
                    rsForm += "." + prmCad.Substring(3, 3);
                    rsForm += "." + prmCad.Substring(6, 3);
                    rsForm += "." + prmCad.Substring(9, 3);
                    rsForm += "," + prmCad.Substring(prmCad.Length - 2, 2);
                }

                rsForm = resta + rsForm;
                prmCad = resta + prmCad;
                return rsForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique...");
                return rsForm = "";
            }
        }
        public string limpMonto(string prmCad)
        {
            try
            {
                prmCad = prmCad.Replace(".", "");
                prmCad = prmCad.Replace(",", "");
                prmCad = Convert.ToInt64(prmCad).ToString();

                if (Convert.ToDouble(prmCad) == 0) { prmCad = ""; }
                return prmCad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique...");
                return prmCad = "";
            }
        }

        public string[] VerfStatTaq(int prmIdUsu)
        {
            string[] rsDat = new string[3];
            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = cn; cnBd.Open();
                    idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spVerfStatTaq";
                        cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsDat[0] = "true";
                            rsDat[1] = "";
                            rsDat[2] = dr["idStat"].ToString();
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                rsDat[0] = "false";
                rsDat[1] = ex.Message;
                rsDat[2] = "";
            }
            return rsDat;
        }


        public List<UserAg> ListUserAg()
        {
            List<UserAg> listUserAg = new List<UserAg>();

            try
            {
                using (MySqlConnection cnBd = new MySqlConnection(cn))
                {
                    cnBd.Open();
                    idCn = 1;

                    using (MySqlCommand cmd = new MySqlCommand("spListUserAg", cnBd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                UserAg _UserAg = new UserAg
                                {
                                    idUserAg = dr.GetInt32("idUserAg"),
                                    cdUserAg = dr.GetString("nombUserAg")

                                };

                                listUserAg.Add(_UserAg);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return listUserAg;
        }

    }
}
