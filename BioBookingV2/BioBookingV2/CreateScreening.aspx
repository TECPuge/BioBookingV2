<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateScreening.aspx.cs" Inherits="BioBookingV2.CreateScreening" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Empty_Space"></div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="well well-sm">
                    <legend class="text-center">Opret ny visning</legend>
                    <div class="Empty_Space"></div>
                    <fieldset>
                        <div id="CScreeningBody" runat="server">
                            <div class="form-group">
                                <asp:Label ID="staticLabel" Text="Vælg Film:" runat="server" class="col-md-3 control-label"></asp:Label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="MovieDropDownList" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <div class="Empty_Space"></div>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="Label1" Text="Vælg Sal:" runat="server" class="col-md-3 control-label"></asp:Label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="TheaterDropDownList" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <div class="Empty_Space"></div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="LabelStartDate" runat="server" Text="Start tidspunkt:" class="col-md-3 control-label"></asp:Label>
                                <div class="col-md-9">
                                    <input id="InputStartDate" type="datetime-local" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator ID="CheckStartDate" runat="server" ControlToValidate="InputStartDate" ForeColor="Red" ErrorMessage="Start tidspunkt er påkrævet!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="LabelEndDate" runat="server" Text="Slut tidspunkt:" class="col-md-3 control-label"></asp:Label>
                                <div class="col-md-9">
                                    <input id="InputEndDate" type="datetime-local" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator ID="CheckEndDate" runat="server" ControlToValidate="InputEndDate" ForeColor="Red" ErrorMessage="Slut tidspunkt er påkrævet!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="Seats" runat="server" Text="Antal Sæder:" class="col-md-3 control-label"></asp:Label>
                                <div class="col-md-9">
                                    <input id="InputSeats" type="text" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator ID="CheckSeats" runat="server" ControlToValidate="InputSeats" ForeColor="Red" ErrorMessage="Antal sæder er påkrævet"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col text-right">
                                    <asp:Button ID="ScreeningCreate" runat="server" class="btn btn-primary btn-lg" OnClick="ScreeningCreate_Click" Text="Opret filmvisning" />
                                </div>
                            </div>
                            <br />
                        </div>
                    </fieldset>
                    <p>
                        <asp:Label ID="VisVisningLabel" runat="server" />
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
