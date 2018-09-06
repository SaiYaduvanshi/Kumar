using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MK_HelperDataLib
{
    public class FormKeyKodcs
    {
        static Keys k; static char[] s;
        public static bool chartype(string FormName, string Object, KeyEventArgs e)
        {
            bool status = false;
            try
            {
                s = null;
                string KEY_CONTROL = ""; string KEY_KEYVALUE = "";
                MK_HelperDataLib.Select.S_GETKEYS(FormName, Object, ref KEY_CONTROL, ref KEY_KEYVALUE);
                if (KEY_KEYVALUE != "")
                {
                    if (KEY_KEYVALUE.Length == 1)
                    {
                        s = KEY_KEYVALUE.ToCharArray(0, KEY_KEYVALUE.Length);
                        int keyvalue = Convert.ToInt32(KeycodeToChar(k + s[KEY_KEYVALUE.Length - 1]));
                        if (KEY_CONTROL.ToString().ToUpper() == "CONTROL")
                        {

                            if (e.Control && e.KeyValue == Convert.ToInt32(keyvalue))
                            {
                                status = true;
                            }
                        }
                        if (KEY_CONTROL.ToString().ToUpper() == "ALT")
                        {

                            if (e.Alt && e.KeyValue == Convert.ToInt32(keyvalue))
                            {
                                status = true;
                            }

                        }
                        if (KEY_CONTROL.ToString().ToUpper() == "SHIFT")
                        {

                            if (e.Shift && e.KeyValue == Convert.ToInt32(keyvalue))
                            {
                                status = true;
                            }

                        }
                        if (KEY_CONTROL.ToString() == "")
                        {
                            if (KEY_KEYVALUE == "Space")
                            {
                                if (e.KeyCode == Keys.Space)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "Escape")
                            {
                                if (e.KeyCode == Keys.Escape)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "Shift")
                            {
                                if (e.KeyCode == Keys.Shift)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "ShiftKey")
                            {
                                if (e.KeyCode == Keys.ShiftKey)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "*")
                            {
                                if (e.KeyCode == Keys.Multiply)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "+")
                            {
                                if (e.KeyCode == Keys.Add)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "-")
                            {
                                if (e.KeyCode == Keys.Subtract)
                                {
                                    status = true;
                                }
                            }
                            if (KEY_KEYVALUE == "/")
                            {
                                if (e.KeyCode == Keys.Divide)
                                {
                                    status = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (KEY_KEYVALUE == "Space")
                        {
                            if (e.KeyCode == Keys.Space)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "Escape")
                        {
                            if (e.KeyCode == Keys.Escape)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "Shift")
                        {
                            if (e.KeyCode == Keys.Shift)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "ShiftKey")
                        {
                            if (e.KeyCode == Keys.ShiftKey)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "*")
                        {
                            if (e.KeyCode == Keys.Multiply)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "+")
                        {
                            if (e.KeyCode == Keys.Add)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "-")
                        {
                            if (e.KeyCode == Keys.Subtract)
                            {
                                status = true;
                            }
                        }
                        if (KEY_KEYVALUE == "/")
                        {
                            if (e.KeyCode == Keys.Divide)
                            {
                                status = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return status;
        }
        public static string KeycodeToChar(Keys keyCode)
        {

            switch (keyCode)
            {
                case Keys.D0:
                    return "0";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.Space:
                    return "Space";
                case Keys.Enter:
                    return "13";
                case Keys.End:
                    return "35";
                case Keys.Tab:
                    return "9";
                case Keys.Shift:
                    return "16";
                case Keys.Up:
                    return "38";
                case Keys.Down:
                    return "40";
                case Keys.Left:
                    return "37";
                case Keys.Right:
                    return "39";

                case Keys.A:
                    return "65";
                case Keys.B:
                    return "66";
                case Keys.C:
                    return "67";
                case Keys.D:
                    return "68";
                case Keys.E:
                    return "69";
                case Keys.F:
                    return "70";
                case Keys.G:
                    return "71";
                case Keys.H:
                    return "72";
                case Keys.I:
                    return "73";
                case Keys.J:
                    return "74";

                case Keys.K:
                    return "75";
                case Keys.L:
                    return "76";
                case Keys.M:
                    return "77";
                case Keys.N:
                    return "78";
                case Keys.O:
                    return "79";
                case Keys.P:
                    return "80";
                case Keys.R:
                    return "82";
                case Keys.S:
                    return "83";
                case Keys.T:
                    return "84";
                case Keys.U:
                    return "85";
                case Keys.V:
                    return "86";
                case Keys.Y:
                    return "89";
                case Keys.Z:
                    return "90";
                case Keys.Q:
                    return "81";
                case Keys.X:
                    return "88";
                case Keys.W:
                    return "87";


                case Keys.NumPad0:
                    return "96";
                case Keys.NumPad1:
                    return "97";
                case Keys.NumPad2:
                    return "98";
                case Keys.NumPad3:
                    return "99";
                case Keys.NumPad4:
                    return "100";
                case Keys.NumPad5:
                    return "101";
                case Keys.NumPad6:
                    return "102";
                case Keys.NumPad7:
                    return "103";
                case Keys.NumPad8:
                    return "104";
                case Keys.NumPad9:
                    return "105";
              
                default:
                case Keys.Multiply:
                    return "106";
                case Keys.Divide:
                    return "111";
                case Keys.Add:
                    return "107";
                case Keys.Subtract:
                    return "109";
                case Keys.Decimal:
                    return "110";
            }
        }
    }
}
