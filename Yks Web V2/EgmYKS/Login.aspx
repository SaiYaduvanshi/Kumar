<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EgmYKS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EGM KANAL V2</title>
    <meta name="description" content="DenizBank" />
    <meta name="author" content="pixelcave" />
    <meta name="robots" content="noindex, nofollow" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="shortcut icon" href="../Favicon/favicon.png" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/plugins.css" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/themes.css" />
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="ErrorPasif" runat="server" Visible="false" Width="100%">
            <div class="alert alert-danger" style="width: 100%">
                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong>
                Hesabınız pasif durumdadır!
            </div>
        </asp:Panel>
        <asp:Panel ID="Erroreposta" runat="server" Visible="false" Width="100%">
            <div class="alert alert-danger" style="width: 100%">
                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong>
                Eposta bilginizi yazınız!
            </div>
        </asp:Panel>
        <asp:Panel ID="Errorpassword" runat="server" Visible="false" Width="100%">
            <div class="alert alert-danger" style="width: 100%">
                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong>
                Şifrenizi yazınız!
            </div>
        </asp:Panel>
        <asp:Panel ID="Errorpassword2" runat="server" Visible="false" Width="100%">
            <div class="alert alert-danger" style="width: 100%">
                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong>
                Eposta veya şifre yalnış.Kontrol ederek tekrar deneyiniz!
            </div>
        </asp:Panel>

        <asp:Panel ID="chapta" runat="server" Visible="False" Width="100%">
            <div class="alert alert-danger" style="width: 100%">
                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong>
                Güvenlik Kodu Yalnış!
            </div>
        </asp:Panel>
        <img src="images/Background1.jpg" alt="Login Full Background" class="full-bg animation-pulseSlow" />


        <div id="login-container" class="animation-fadeIn">

            <div class="login-title text-center">
                <h1>
                    <img src="images/İcon.png" height="48" />
                    <strong>Emniyet Genel Müdürlüğü</strong><br />
                    <strong>YKS Kanal V2</strong>
                </h1>
            </div>
            <div class="block push-bit">
                <div action="" method="post" id="form-login" class="form-horizontal form-bordered form-control-borderless">
                    <div class="form-group">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-lg" placeholder="Sicil No..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-lg" placeholder="Şifre..." TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-actions">
                        <div class="col-xs-4">
                            <label class="" data-toggle="tooltip" title="Beni Hatırla">
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" Text="" />
                                <span>Beni Hatırla</span>
                            </label>
                            <br />
                            <label class="" data-toggle="tooltip" title="Beni Hatırla">
                                <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true" Text="" />
                                <span>Şifremi Hatırla</span>
                            </label>
                        </div>
                        <div class="col-xs-8 text-right">
                            <asp:Button ID="Button1" runat="server" Text=" Giriş " CssClass="btn btn-primary" OnClick="Button1_Click" />

                        </div>
                    </div>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
