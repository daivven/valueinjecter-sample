<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AspNetMVCSample.Models.PersonViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Request To Entity</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
  <fieldset>
            <legend>Fields</legend>
            <% Html.RenderPartial("person"); %>                    
            <p>
                <input type="submit" value="Submit" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

