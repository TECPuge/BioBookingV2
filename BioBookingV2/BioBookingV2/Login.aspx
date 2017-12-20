<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BioBookingV2.Login1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="Empty_Space"></div>
        <div class="Empty_Space"></div>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="well well-sm">
                    <!-- <form class="form-horizontal" method="post"> -->
                    <legend class="text-center">Log in</legend>
                    <div class="Empty_Space"></div>
                    <fieldset>
                        <!-- Brugernavn input-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="name">Brugernavn: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- Password input-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="email">Password: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- Description body -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="message"></label>
                            <div class="col-md-9">
                                <asp:CheckBox ID="chkBoxRememberMe" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Husk mig" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-9">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>

                        <!-- Form actions -->
                            <div class="row">
                                <div class="col test pull-right">
                                   <asp:LinkButton ID="Button2" runat="server" class="btn btn-primary btn-lg" href="/register" Text="Opret ny bruger"></asp:LinkButton>
                                    <asp:Button ID="Button1" runat="server" type="submit" class="btn btn-primary btn-lg" OnClick="Button1_Click" Text="Log in"></asp:Button>
                                </div>


                            </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
