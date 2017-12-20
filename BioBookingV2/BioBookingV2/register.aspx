<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BioBookingV2.WebForm1" %>

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
                        <!-- firstname input-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="name">Brugernavn: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername0" runat="server" ErrorMessage="Brugernavn er påkrævet" Text="" ControlToValidate="txtUserName" ForeColor="Red" ></asp:RequiredFieldValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- firstname input -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="firstname">Fornavn: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Firstname" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername1"
                                    runat="server" ErrorMessage="Fornavn er påkrævet" Text=""
                                    ControlToValidate="txtUserName" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- lastname input -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="lastname">Efternavn: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Lastname" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername"
                                    runat="server" ErrorMessage="Efternavn er påkrævet" Text=""
                                    ControlToValidate="txtUserName" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- email input -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="email">Email: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="Email er påkrævet" Text=""
                                    ControlToValidate="Email" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- password input -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="password">Password: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword"
                                    runat="server" ErrorMessage="Password er påkrævet" Text=""
                                    ControlToValidate="txtPassword" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>

                        <!-- Check password -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="confirmpassword">Bekræft: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword"
                                    runat="server" ErrorMessage="Passwords skal være ens" Text=""
                                    ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                    ErrorMessage="Passwords skal være ens"
                                    ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                    ControlToCompare="txtPassword" Display="Dynamic"
                                    Type="String" Operator="Equal" Text="">
                                </asp:CompareValidator>
                                <div class="Empty_Space"></div>
                            </div>
                        </div>
                        <!-- Form actions -->
                        <div class="row">
                            <div class="col test pull-right">
                                <asp:Button ID="btnRegister" class="btn btn-primary btn-lg" runat="server" Text="Register" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </fieldset>
                    <div class="row">
                        <asp:Label id="lblMessage" runat="server" Forecolor="Red" class="leftpadding"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
