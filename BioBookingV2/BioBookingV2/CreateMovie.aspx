<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateMovie.aspx.cs" Inherits="BioBookingV2.CreateMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Empty_Space"></div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="well well-sm">
                    <!-- <form class="form-horizontal" method="post"> -->
                    <legend class="text-center">Opret ny film</legend>
                    <div class="Empty_Space"></div>
                    <fieldset>
                        <!-- Title input-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="name">Titel</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="InputTitle" runat="server" class="form-control" placeholder="Sharknado 2"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Price input-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="email">Billet pris</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="InputPrice" name="InputPrice" type="text" placeholder="kr. 50" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Description body -->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="message">Beskrivelse</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" class="form-control" ID="InputDescription" name="InputDescription" placeholder="Fin and April are on their way to New York City, until a category seven hurricane spawns heavy rain, storm surges, and deadly Sharknadoes..."></asp:TextBox>
                            </div>
                        </div>

                        <!-- Upload billede-->
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="message">Upload billede</label>
                            <div class="col-md-9">
                                <asp:FileUpload ID="FileUploadPoster" runat="server" />
                            </div>
                        </div>

                        <!-- Form actions -->
                        <div class="form-group">
                            <div class="col text-right">
                                <asp:Button runat="server" type="submit" class="btn btn-primary btn-lg" OnClick="ButtonCreate_Click" Text="Opret film"></asp:Button>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>

