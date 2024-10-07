using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using DevComponents.DotNetBar;

namespace ventas_loteria
{
    class clsMet
    {
        public static string cadena_conexion;
        public static string idPerf;
        public static string nombUsu;
        public static string idUsu;
        public static string idGrup;
        public static int monto_multiplo_jug;
        public static int monto_min_jug;
        public static int monto_max_jug;
        public static int montMaxTck;
        public static int monto_Xunidad;
        public static int cant_dia_cad_ticket;
        public static string nota_msj_ticket;
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

        public static MySqlConnection cn_bd = new MySqlConnection();
        public static void Desconectar() { if (cn_bd.State == ConnectionState.Open) cn_bd.Close(); }
        public static void conectar()
        {
            try
            {
                if (cn_bd.State == ConnectionState.Closed)
                {
                    cn_bd.ConnectionString = cadena_conexion; cn_bd.Open();
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

        public static string hora_normal(string prm_hora)
        {

            int hora = Convert.ToInt32(prm_hora.Substring(0, 2));
            string minuto = prm_hora.Substring(3, 2);
            string hora_new = "";

            if ((hora >= 0) && (hora < 12)) { hora_new = hora + ":" + minuto + " A.M"; }
            else if (hora == 12) { hora_new = hora + ":" + minuto + " P.M"; }
            else if ((hora > 12) && (hora <= 23)) { hora = hora - 12; hora_new = hora + ":" + minuto + " P.M"; }
            return hora_new;

        }

        public static string procesar_rif(string prm_rif)
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
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public string verfLogUsu(string prmUsu)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_verf_login";
                cmd.Parameters.AddWithValue("prm_usuario", prmUsu);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["nick"].ToString() + "?" + dr["clave"].ToString() + "?" +
                                dr["id_status"].ToString() + "?" + dr["id_perfil"].ToString() + "?" +
                                dr["id_usuario"].ToString() + "?" + dr["nomb_perfil"].ToString() + "?" +
                                dr["id_grupo"].ToString() + "?" + dr["monto_max_jug"].ToString() + "?" +
                                dr["monto_max_ticket"].ToString() + "?" + dr["monto_Xunidad"].ToString() + "?" +
                                dr["monto_multiplo_jug"].ToString() + "?" + dr["monto_min_jug"].ToString() + "?" +
                                dr["nomb_impresora"].ToString() + "?" + dr["ancho_ticket"].ToString() + "?" +
                                dr["num_letra"].ToString() + "?" + dr["nombDivisa"].ToString();

                }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public string[] busPrmGral()
        {
            string[] rsPrmGral = new string[2];
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_parametros_grales";
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsPrmGral[0] = dr["cant_dia_cad_ticket"].ToString();
                    rsPrmGral[1] = dr["nota_msj_ticket"].ToString();
                }
                else
                {
                    rsPrmGral[0] = "";
                    rsPrmGral[1] = "";
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ver");
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
                rsPrmGral[0] = ex.Message;
                rsPrmGral[1] = "";
            }
            finally { clsMet.Desconectar(); }
            return rsPrmGral;
        }

        public string[] verfMacTaq(string prmMac, int prmIdUsuario)
        {
            string[] rsDatos = new string[3];
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_verifica_mac_equipo";
                cmd.Parameters.AddWithValue("prmMac", prmMac);
                cmd.Parameters.AddWithValue("prmIdUsuario", prmIdUsuario);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    rsDatos[0] = "true";
                    rsDatos[1] = dr["idStatus"].ToString();
                    rsDatos[2] = dr["idUsuario"].ToString();
                }
                else
                {
                    rsDatos[0] = "false";
                    rsDatos[1] = "0";
                    rsDatos[2] = "0";
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message, "Verifique.");
                rsDatos[0] = "false";
                rsDatos[1] = "0";
                rsDatos[2] = "0";
            }
            finally { clsMet.Desconectar(); }
            return rsDatos;
        }

        public string busClavUsu(int prmIdUsu)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_verf_cambio_clave";
                cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["clave"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public string cambClavUsuario(int prm_id_usuario, string prm_clave)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_act_cambio_clave";
                cmd.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                cmd.Parameters.AddWithValue("prm_clave", prm_clave);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busGrup(int prmIdUsu, int prmIdPerf,
                                 int prmIdGrup)
        {
            DataTable dt = new DataTable("busGrup");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spBusGrupConf";
                cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busLetRif()
        {
            DataTable dt = new DataTable("busLetRif");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_letra_rif";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busCodTlf()
        {
            DataTable dt = new DataTable("busCodTlf");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_cod_area_telf";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busStat()
        {
            DataTable dt = new DataTable("busStat");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_status";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busPerf(int prmIdPerf)
        {
            DataTable dt = new DataTable("busPerf");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spBusPerf";
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable bus_grupos_sist_Xfiltro_nomb(string prm_nomb_grupo)
        {
            DataTable dt = new DataTable("bus_grupos_sist_Xfiltro_nomb");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_grupos_Xfiltro_nomb";
                cmd.Parameters.AddWithValue("prm_nomb_grupo", prm_nomb_grupo);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public string grdActGrupos(int prm_id_grupo, string prm_nomb_grupo, string prm_razon_social,
                                     string prm_rif, string prm_nro_telef, string prm_direccion,
                                    string prm_email, int prm_id_status)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_grd_act_grupos";
                cmd.Parameters.AddWithValue("prm_id_grupo", prm_id_grupo);
                cmd.Parameters.AddWithValue("prm_nomb_grupo", prm_nomb_grupo);
                cmd.Parameters.AddWithValue("prm_razon_social", prm_razon_social);
                cmd.Parameters.AddWithValue("prm_rif", prm_rif);
                cmd.Parameters.AddWithValue("prm_nro_telef", prm_nro_telef);
                cmd.Parameters.AddWithValue("prm_direccion", prm_direccion);
                cmd.Parameters.AddWithValue("prm_email", prm_email);
                cmd.Parameters.AddWithValue("prm_id_status", prm_id_status);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busUsu(int prmIdGrupo)
        {
            DataTable dt = new DataTable("busUsu");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_usuarios_grupos";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrupo);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception) { dt = null; }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public string cantUsuGrup(int prmIdGrup)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_cant_usuario";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["cant_usuarios_grupo"].ToString(); }
                else { rsDat = ""; }
                dr.Close();

            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public string grdActUsuarios(int prmIdGrupo, int prmIdUsuario, int prmIdDivisa, string prmNombUsuario,
                                        string prmClave, string prmEmail, int prmIdStatus,
                                        int prmIdPerfil, int prm_id_preg_seg, string prm_resp_seg,
                                        string prmPorcTaq, string prmPorcCasa, string prmPorcSist,
                                        int prmMontoMaxJug, int prmMontoMaxTicket, int prmMontoxUnidad,
                                        int prmIdTipoCuadre, int prmMultJug, int prmMinJug,
                                        int prmUnidBase, int prmCierreSorteo, string prmMac)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_grd_act_usuarios";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrupo);
                cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsuario);
                cmd.Parameters.AddWithValue("prmIdDivisa", prmIdDivisa);
                cmd.Parameters.AddWithValue("prm_nomb_usuario", prmNombUsuario);
                cmd.Parameters.AddWithValue("prm_clave", prmClave);
                cmd.Parameters.AddWithValue("prm_email", prmEmail);
                cmd.Parameters.AddWithValue("prm_id_preg_seg", prm_id_preg_seg);
                cmd.Parameters.AddWithValue("prm_resp_seg", prm_resp_seg);
                cmd.Parameters.AddWithValue("prm_id_status", prmIdStatus);
                cmd.Parameters.AddWithValue("prm_id_perfil", prmIdPerfil);
                cmd.Parameters.AddWithValue("prm_porc_taquilla", prmPorcTaq);
                cmd.Parameters.AddWithValue("prm_porc_casa", prmPorcCasa);
                cmd.Parameters.AddWithValue("prm_porc_sist", prmPorcSist);
                cmd.Parameters.AddWithValue("prm_monto_max_jug", prmMontoMaxJug);
                cmd.Parameters.AddWithValue("prm_monto_max_ticket", prmMontoMaxTicket);
                cmd.Parameters.AddWithValue("prm_monto_xUnidad", prmMontoxUnidad);
                cmd.Parameters.AddWithValue("prm_id_tipo_cuadre", prmIdTipoCuadre);
                cmd.Parameters.AddWithValue("prm_multiplo_jug", prmMultJug);
                cmd.Parameters.AddWithValue("prm_minimo_jug", prmMinJug);
                cmd.Parameters.AddWithValue("prm_unidad_base", prmUnidBase);
                cmd.Parameters.AddWithValue("prm_cierre_sorteo", prmCierreSorteo);
                cmd.Parameters.AddWithValue("prmMac", prmMac);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busPregSeg()
        {
            DataTable dt = new DataTable("busPregSeg");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_preg_seguridad";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busStatMac()
        {
            DataTable dt = new DataTable("busStatMac");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_status_mac";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable bus_status_mac_filtro()
        {
            DataTable dt = new DataTable("bus_status_mac_filtro");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_status_mac_filtro";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busMac(int prmIdPerf, int prmIdGrup)
        {
            DataTable dt = new DataTable("busMac");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_mac_adrress";
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa" + ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busTipCuad()
        {
            DataTable dt = new DataTable("busTipCuad");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_tipo_cuadre";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busDivisa()
        {
            DataTable dt = new DataTable("busDivisa");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spBusDivisa";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busMacXfiltro(string prm_dir_mac)
        {
            DataTable dt = new DataTable("busMacXfiltro");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mac_Xfiltro";
                command.Parameters.AddWithValue("prm_dir_mac", prm_dir_mac);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busMacXfiltStat(int prmIdStat)
        {
            DataTable dt = new DataTable("busMacXfiltStat");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mac_Xfiltro_status";
                command.Parameters.AddWithValue("prm_id_status", prmIdStat);

                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable bus_mac_nuevas()
        {
            DataTable dt = new DataTable("bus_mac_nuevas");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mac_address_nuevas";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string grd_asocia_mac(int prm_id_grupo_usuario, int prm_id_usuario,
                                     int prm_id_mac_nueva)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_grd_act_mac_nueva";
                command.Parameters.AddWithValue("prm_id_grupo_usuario", prm_id_grupo_usuario);
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_id_mac_nueva", prm_id_mac_nueva);

                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }


        public string actStatMac(int prm_id_mac, int prm_id_status)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_act_status_mac";
                command.Parameters.AddWithValue("prm_id_mac", prm_id_mac);
                command.Parameters.AddWithValue("prm_id_status", prm_id_status);

                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busLotProcRs()
        {
            DataTable dt = new DataTable("busLotProcRs");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_sorteos_proc_result";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }


            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busTipProc()
        {
            DataTable dt = new DataTable("busTipProc");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_bus_tipo_proc_datos";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busLot(int prmIdUsu)
        {
            DataTable dt = new DataTable("busLot");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_sorteos";
                command.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busNombProd()
        {
            DataTable dt = new DataTable("busNombProd");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spBusNombProd";
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable bus_sorteos(int prm_id_loteria)
        {

            DataTable dt = new DataTable("bus_sorteos");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_sorteos";
                command.Parameters.AddWithValue("prm_id_loteria", prm_id_loteria);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string grd_jugada(int prm_id_grupo, int prm_id_usuario,
                                int prm_id_loteria, int prm_id_sorteos,
                                string prm_codigo, string prm_monto,
                                string prm_id_temp_jug)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_grd_jugada_seleccionada";
                command.Parameters.AddWithValue("prm_id_grupo", prm_id_grupo);
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_id_loteria", prm_id_loteria);
                command.Parameters.AddWithValue("prm_id_sorteos", prm_id_sorteos);
                command.Parameters.AddWithValue("prm_codigo", prm_codigo);
                command.Parameters.AddWithValue("prm_monto", prm_monto);
                command.Parameters.AddWithValue("prm_id_temp_jug", prm_id_temp_jug);

                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busJug(string prmNroTick)
        {
            DataTable dt = new DataTable("busJugs");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_jugadas";
                command.Parameters.AddWithValue("prm_nro_ticket", prmNroTick);

                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                clsMet.Desconectar();
            }
            return dt;
        }

        public string verf_jugadas_cerrada(int prm_id_usuario, int prm_id_loteria,
                                              int prm_id_sorteo)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();

            try
            {

                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_verf_jug_sorteo_cerrado";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_id_loteria", prm_id_loteria);
                command.Parameters.AddWithValue("prm_id_sorteo", prm_id_sorteo);

                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }


        public string dlt_jugada(int prm_id_tmp_jugada, int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_borra_jugada";
                command.Parameters.AddWithValue("prm_id_tmp_jugada", prm_id_tmp_jugada);
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable bus_producto(int prm_id_loteria)
        {

            DataTable dt = new DataTable("bus_producto");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_producto";
                command.Parameters.AddWithValue("prm_id_loteria", prm_id_loteria);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string verfHoraServ(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_bus_hora_servidor";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["fechaHoraServ"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public string bus_total_jug(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_monto_total_jug";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["monto_jug"].ToString(); }
                else { rsDat = ""; }
                dr.Close();

            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string[] busFechHoraServ()
        {
            string[] rsDat = new string[2];
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_busFechaHoraServ";
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                rsDat[0] = dr["fechaAct"].ToString();
                rsDat[1] = dr["horaAct"].ToString();
                dr.Close();
            }
            catch (Exception ex) { rsDat[0] = "0"; rsDat[1] = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string verf_jug_imp_ticket(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_ver_cant_jug_imp_ticket";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["cant_jug"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string busInfTicket(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_info_reimprimir_ticket";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["prm_cant_ticket"].ToString() + "?" + dr["prm_permit_reimp"].ToString() + "?" +
                               dr["prm_cant_min_reimp_ticket"].ToString() + "?" + dr["prm_nro_ticket"].ToString() + "?" +
                               dr["prm_nro_serial"].ToString() + "?" + dr["prm_fecha_reg"].ToString() + "?" +
                               dr["prm_hora_reg"].ToString() + "?" + dr["prm_monto_ticket"].ToString();

                }

                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string grd_ticket_usuario(int prm_id_grupo, int prm_id_usuario,
                                        string prm_monto_ticket)
        {
            string rsDat = "";
            string msj_info = "";
            Boolean rs_proceso = false;

            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            MySqlTransaction myTrans = null;

            try
            {
                command.Connection = clsMet.cn_bd;
                myTrans = clsMet.cn_bd.BeginTransaction();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_grd_ticket";
                command.Parameters.AddWithValue("prm_id_grupo", prm_id_grupo);
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_monto_ticket", prm_monto_ticket);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rs_proceso = true;
                    rsDat = rs_proceso + "?" + dr["prm_cont_ticket"].ToString()
                                    + "?" + dr["prm_nro_Serial"].ToString() + "?" +
                               dr["fecha_ticket"].ToString() + "?" + dr["hora_ticket"].ToString();

                }

                else { rsDat = ""; }
                dr.Close();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                rsDat = rs_proceso + "?" + ex.Message;
                try { if (clsMet.cn_bd.State == ConnectionState.Open) { myTrans.Rollback(); } }
                catch (MySqlException error)
                {
                    if (myTrans.Connection != null)
                    {
                        msj_info = "Una excepción de tipo \"" + error.GetType() + " \"";
                        msj_info += " se encontró al intentar revertir la transacción.";

                        MessageBox.Show(msj_info, "Transacción Fallida...");
                    }
                }

                msj_info = "Una excepción de tipo: \"" + ex.GetType() + "\"";
                msj_info += "\n se encontró al insertar los datos. \n Tome nota del";
                msj_info += " siguiente error: \"" + ex.Message + "\"";

                MessageBox.Show(msj_info, "Transacción Fallida...");
            }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string verf_exits_ticket(long prm_nro_ticket, long prm_nro_serial)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_verf_exits_ticket";
                command.Parameters.AddWithValue("prm_nro_ticket", prm_nro_ticket);
                command.Parameters.AddWithValue("prm_nro_serial", prm_nro_serial);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["cant_ticket"].ToString() + "?" + dr["fecha_reg"].ToString() + "?" +
                                dr["hora_reg"].ToString();
                }

                else { rsDat = ""; }
                dr.Close();

            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string busCuadCajDiario(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_cuadre_caja_diario";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);

                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["prm_total_venta"].ToString() + "?" + dr["prm_total_pagado"].ToString()
                                + "?" + dr["prm_total_anulado"].ToString() + "?" + dr["prm_total_caja"].ToString()
                                + "?" + dr["prm_ultimo_ticket"].ToString();
                }

                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string bus_repet_ultimo_ticket(int prm_id_usuario)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_repet_ultimo_ticket";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["permitir"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string limpia_jug_pend(int prm_id_usuario)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_limpia_jug_pend";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);

                rsDat = Convert.ToString(command.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string verfStatTck(int prmIdUsu, string prmNroTck,
                                  string prmNroSer)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string actStatTck(int prmIdUsu, string prmNroTck,
                                string prmNroSer)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string verfDetTckAnu(string prmNroTck)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_verf_det_ticket_anula";
                command.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["rs_anular_ticket"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string verfExitsMostTick(int prmIdUsu, long prmNroTick,
                                                    long prmNroSerial)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_verf_exists_mostrar_ticket";
                command.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                command.Parameters.AddWithValue("prm_nro_ticket", prmNroTick);
                command.Parameters.AddWithValue("prm_nro_serial", prmNroSerial);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows) { rsDat = dr["cant_ticket"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string SPMostInfTck(string prmNroTck, string prmNroSerial)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_mostrar_ticket_info";
                cmd.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                cmd.Parameters.AddWithValue("prm_nro_serial", prmNroSerial);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["nick"].ToString() + "?" + dr["nmb_status_ticket"].ToString()
                                + "?" + dr["monto_ticket"].ToString() + "?" + dr["monto_pagado"].ToString()
                                 + "?" + dr["fecha_reg"].ToString() + "?" + dr["hora_reg"].ToString();
                }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string SPMostInfTck(string prmNroTck)
        {
            string rsDat = "";
            int prmIdGrup = 0;
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                prmIdGrup = Convert.ToInt16(clsMet.idGrup);
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPbusInfTckAn";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["nick"].ToString() + "?" + dr["nombStatTck"].ToString()
                                + "?" + dr["mTck"].ToString() + "?" + dr["mPag"].ToString()
                                 + "?" + dr["fechReg"].ToString() + "?" + dr["horReg"].ToString() + "?" +
                                 dr["idStat"].ToString();
                }

                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string busMostDetTck(long prmNroTck, long prmNroSerial)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mostrar_ticket_det";
                command.Parameters.AddWithValue("prm_nro_ticket", prmNroTck);
                command.Parameters.AddWithValue("prm_nro_serial", prmNroSerial);
                MySqlDataReader dr = command.ExecuteReader();

                string nombLot = "", horaSort = "";
                string codJug = "", nombProd = "";
                int idLot = 0, idSort = 0;
                int contDetJug = 0;
                long mJug = 0;

                while (dr.Read())
                {
                    codJug = dr["codigo_jugada"].ToString().Trim();
                    nombProd = dr["nomb_product"].ToString().Trim();
                    mJug = Convert.ToInt64(dr["monto"].ToString().Trim());

                    if ((idLot != Convert.ToInt32(dr["id_loteria"].ToString()))
                        || idSort != Convert.ToInt32(dr["id_sorteo"].ToString()))
                    {

                        nombLot = dr["nomb_loteria"].ToString();
                        horaSort = dr["hora_sorteo"].ToString();
                        rsDat += "-------------------------------------\n";
                        rsDat += nombLot + "  ";
                        rsDat += clsMet.hora_normal(horaSort);
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string SPMostDetTckAn(long prmNroTck)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
                        rsDat += nombLot + "  " + clsMet.hora_normal(horaSort);
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }

        public DataTable busStatTckFilt()
        {
            DataTable dt = new DataTable("busStatTckFilt");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_status_ticket_filtro";

                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busMovStatTck(int prmIdUsu)
        {
            DataTable dt = new DataTable("busMovStatTck");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mov_status_ticket";
                command.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busStatTckXfilt(int prmIdUsu, string prmFechIni,
                                     string prmFechFin, int prmIdStatTck)
        {
            DataTable dt = new DataTable("busStatTckXfilt");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_mov_status_ticket_Xfiltro";
                command.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                command.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                command.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                command.Parameters.AddWithValue("prm_id_status_ticket", prmIdStatTck);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string busTotVent(int prmIdUsu, string prmFechIni,
                                 string prmFechFin, int prmIdStatTck)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_totales_mov_ventas";
                command.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                command.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                command.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                command.Parameters.AddWithValue("prm_id_status_ticket", prmIdStatTck);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["cant_ticket"].ToString() + "? " + dr["monto_total_entrada"].ToString()
                        + "? " + dr["monto_total_salida"].ToString();
                }

                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable busTotVentas(int prmIdUsu)
        {
            DataTable dt = new DataTable("busTVentas");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_totales_taq";
                command.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busTotVentasFiltro(int prm_id_usuario, string prm_fecha_ini,
                                                       string prm_fecha_fin)
        {
            DataTable dt = new DataTable("bus_totales_venta_Xfiltro");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_totales_taq_Xfiltro";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_fecha_ini", prm_fecha_ini);
                command.Parameters.AddWithValue("prm_fecha_fin", prm_fecha_fin);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string busTotVentas(int prm_id_usuario, string prm_fecha_ini,
                                       string prm_fecha_fin)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_totales_ventas_taq";
                command.Parameters.AddWithValue("prm_id_usuario", prm_id_usuario);
                command.Parameters.AddWithValue("prm_fecha_ini", prm_fecha_ini);
                command.Parameters.AddWithValue("prm_fecha_fin", prm_fecha_fin);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["monto_entrada"].ToString() + "? " + dr["monto_salida"].ToString()
                        + "? " + dr["monto_taq"].ToString() + "? " + dr["monto_utilidad"].ToString();
                }

                else { rsDat = ""; }
                dr.Close();

            }
            catch (Exception ex)
            {
                rsDat = ex.Message;
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
            }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable busJugProcRs(int prmIdPerf, int prmIdGrup, 
                                    string prmFech)
        {
            DataTable dt = new DataTable("busJugProcRs");
            MySqlDataAdapter da;
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusJugProcRs";
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmFech", prmFech);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (MySqlException ex) { dt = null; MessageBox.Show("busJugProcRs: " + ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busJugProcRsMan(int prmIdPerf, int prmIdGrup, 
                                        int prmIdSort,string prmFech)
        {
            DataTable dt = new DataTable("busJugProcRsMan");
            MySqlDataAdapter da;
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusJugProcRsMan";
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                cmd.Parameters.AddWithValue("prmFech", prmFech);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (MySqlException ex) { dt = null; MessageBox.Show("busJugProcRs: " + ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable listProdBloq(int prmIdGrup, int prmIdLot)
        {
            DataTable dt = new DataTable("listProdBloq");
            MySqlDataAdapter da;
            clsMet.conectar();
            MySqlCommand command = new MySqlCommand();
            try
            {
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spListProdBloq";
                command.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                command.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable listProdBloqFilt(int prmIdGrup, int prmIdLot, 
                                          int prmIdSort)
        {
            DataTable dt = new DataTable("listProdBloqFilt");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListProdBloqFilt";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busContVentTaq(int prmIdLot)
        {
            DataTable dt = new DataTable("busContVentTaq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spContVentTaq";
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busJugPendProc(int prmIdPerf, int prmIdGrup)
        {
            DataTable dt = new DataTable("busJugPendProc");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusJugPendProc";
                cmd.Parameters.AddWithValue("prmIdPerf", prmIdPerf);
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable bus_sorteo_proc_result(int prm_id_loteria)
        {

            DataTable dt = new DataTable("bus_sorteo_proc_result");
            MySqlDataAdapter da;
            MySqlCommand command = new MySqlCommand();
            try
            {
                clsMet.conectar();
                command.Connection = clsMet.cn_bd;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_bus_sorteos_proc_result";
                command.Parameters.AddWithValue("prm_id_loteria", prm_id_loteria);
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string actStatProd(int prmIdGrup, int prmIdUsu,
                                    int prmIdLot, int prmIdSort,
                                    string prmCodProd, int prmIdStat)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string actStatProdTod(int prmIdGrup, int prmIdLot,
                                   string prmCodProd, int prmIdStat)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spActStatProdTod";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                cmd.Parameters.AddWithValue("prmCodProd", prmCodProd);
                cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                rsDat = cmd.ExecuteNonQuery() == 0 ? "true" : "false";
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string grdActRstLot(int prmIdLot, int prmIdSort,
        string prmResultLot, string prmFechLot)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_grd_act_result_lot";
                cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                cmd.Parameters.AddWithValue("prm_id_sorteos", prmIdSort);
                cmd.Parameters.AddWithValue("prm_result_lot", prmResultLot);
                cmd.Parameters.AddWithValue("prm_fecha_loteria", prmFechLot);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());

            }
            catch (MySqlException ex) { rsDat = ex.Message; MessageBox.Show(rsDat); }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public string busProcRsLot(int prmIdDetJug, int prmIdLot,
                                   int prmIdSort, string prmRstLot)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_act_result_loteria";
                cmd.Parameters.AddWithValue("prmIdDetJug", prmIdDetJug);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                cmd.Parameters.AddWithValue("prmRsLot", prmRstLot);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows) { rsDat = dr["statTck"].ToString(); }
                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; MessageBox.Show(ex.Message,"busProcRsLot"); }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable bus_cuadre_taq(int prmIdGrup, int prmIdUsu)
        {
            DataTable dt = new DataTable("bus_cuadre_taq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_totales_grupo_taq";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busGrupTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busGrupTaq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPbusGrupTaq";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable BusTaqContVent(int prmIdGrup)
        {
            DataTable dt = new DataTable("BusTaqContVent");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spBusTaqContVent";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable BusGrup()
        {
            DataTable dt = new DataTable("BusGrup");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spBusGrup";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show("aaa: " + ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busVentGrup(int prmIdgrup, string prmFechIni,
                                                 string prmFechFin)
        {
            DataTable dt = new DataTable("busVentTodGrup");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusTotGrup";
                cmd.Parameters.AddWithValue("prmIdgrup", prmIdgrup);
                cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busVentGrupTod(int prmIdgrup, string prmFechIni,
                                         string prmFechFin)
        {
            DataTable dt = new DataTable("busVentTodGrup");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusTotGrupTod";
                cmd.Parameters.AddWithValue("prmIdgrup", prmIdgrup);
                cmd.Parameters.AddWithValue("prmFechIni", prmFechIni);
                cmd.Parameters.AddWithValue("prmFechFin", prmFechFin);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busTotCuadGrupTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busTotCuadGrupTaq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_totales_grupo_taq";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busTotCuadGrupTaqFilt(int prmIdGrup, int prmIdUsu,
                                                string prmFechIni, string prmFechFin)
        {
            DataTable dt = new DataTable("busTotCuadreGrupoTaqFiltro");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_totales_grupo_taq_Xfiltro";
                cmd.Parameters.AddWithValue("prm_id_grupo", prmIdGrup);
                cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                cmd.Parameters.AddWithValue("prm_fecha_ini", prmFechIni);
                cmd.Parameters.AddWithValue("prm_fecha_fin", prmFechFin);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busTotGrupoTaqXDiv(int prmIdGrup, int prmIdUsu,
                                               int prmIdDiv, string prmFechaIni,
                                               string prmFechaFin)
        {
            DataTable dt = new DataTable("busTotGrupoTaqXDiv");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public string busConfImp(int prmIdUsu)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_config_impresora";
                cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsDat = dr["nomb_impresora"].ToString() + "?" + dr["ancho_ticket"].ToString() + "?" +
                                dr["num_letra"].ToString();

                }

                else { rsDat = ""; }
                dr.Close();
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable busAnchTck()
        {
            DataTable dt = new DataTable("busAnchTck");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_ancho_ticket";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable busNumLet()
        {
            DataTable dt = new DataTable("busNumLet");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_num_letra";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string actGrdConfImp(int prmIdUsu, string prmNombImp,
                      string prmAnchTck, string prmNumLet)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_grd_act_config_imp";
                cmd.Parameters.AddWithValue("prm_id_usuario", prmIdUsu);
                cmd.Parameters.AddWithValue("prm_nomb_imp", prmNombImp);
                cmd.Parameters.AddWithValue("prm_ancho_ticket", prmAnchTck);
                cmd.Parameters.AddWithValue("prm_num_letra", prmNumLet);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable busResultLot()
        {
            DataTable dt = new DataTable("busResultLot");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_result_lot";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busLotRs()
        {
            DataTable dt = new DataTable("busLotRs");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_lot_result";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busResultLotfilt(int prmIdLot, string prmFech)
        {
            DataTable dt = new DataTable("busResultLotfilt");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_bus_result_lot_Xfiltro";
                cmd.Parameters.AddWithValue("prm_id_loteria", prmIdLot);
                cmd.Parameters.AddWithValue("prm_fecha", prmFech);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busGrupTod()
        {
            DataTable dt = new DataTable("busGrupTod");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBusGrupTod";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string verf_grd_repet_ticket(int prmIdUsu, string prmNroTck)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }


        public DataTable repet_jugada_ticket(string prmNroTck, int prmIdLot,
                                            int prmIdSort, string prmNombLot,
                                            string prmHorSort, string prmAbLot)
        {
            DataTable dt = new DataTable("repet_jugada_ticket");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            clsMet.conectar();
            try
            {
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string anTck(string prmNroTck)
        {
            string rsDat = "";
            int prmIdGrup = 0;
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                prmIdGrup = Convert.ToInt16(clsMet.idGrup);
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPAnTckAdm";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmNroTck", prmNroTck);
                rsDat = Convert.ToString(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable busJugTaq(int prmIdLot, int prmIdSort,
                                    int prmIdTaq, string prmFech)
        {
            DataTable dt = new DataTable("busJugTaq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
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
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable busLimTaq(int prmIdGrup)
        {
            DataTable dt = new DataTable("busLimTaq");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListLimTaq";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public string actLimTaq(int prmIdGrup, int prmIdTaq,
                                string prmMmaxAn)
        {

            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spActLimTaq";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdTaq", prmIdTaq);
                cmd.Parameters.AddWithValue("prmMmaxAn", prmMmaxAn);
                rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable listLotTod()
        {
            DataTable dt = new DataTable("listLotTod");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListLotTod";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable listLotContVent()
        {
            DataTable dt = new DataTable("listLotContVent");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "splistLotContVent";
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public DataTable listSortTod(int prmIdLot)
        {
            DataTable dt = new DataTable("listSortTod");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListSortTod";
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable listSortContVentTod(int prmIdLot)
        {
            DataTable dt = new DataTable("listSortContVentTod");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListSortContVentTod";
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable listSortVentTod(int prmIdUsu, int prmIdLot)
        {
            DataTable dt = new DataTable("listSortVentTod");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListSortVentTod";
                cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }

        public string actStatSort(int prmIdGrup, int prmIdUsu,
                                  int prmIdLot, int prmIdSort,
                                  int prmIdStat)
        {
            string rsDat = "";
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spActStatSort";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdUsu", prmIdUsu);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                cmd.Parameters.AddWithValue("prmIdStat", prmIdStat);
                rsDat = cmd.ExecuteNonQuery() > 0 ? "true" : "false";
            }
            catch (Exception ex) { rsDat = ex.Message; }
            finally { clsMet.Desconectar(); }
            return rsDat;
        }
        public DataTable listSortBloq(int prmIdGrup, int prmIdLot)
        {
            DataTable dt = new DataTable("listSortBloq");
            MySqlDataAdapter da;
            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListSortBloq";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
        public DataTable listProdSortFilt(int prmIdGrup, int prmIdLot, 
                                          int prmIdSort)
        {
            DataTable dt = new DataTable("listProdBloqFilt");
            MySqlDataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                clsMet.conectar();
                cmd.Connection = clsMet.cn_bd;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListSortBloqFilt";
                cmd.Parameters.AddWithValue("prmIdGrup", prmIdGrup);
                cmd.Parameters.AddWithValue("prmIdLot", prmIdLot);
                cmd.Parameters.AddWithValue("prmIdSort", prmIdSort);
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) { dt = null; MessageBox.Show(ex.Message); }
            finally { clsMet.Desconectar(); }
            return dt;
        }
    }
}
