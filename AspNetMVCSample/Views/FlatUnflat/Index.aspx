<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AspNetMVCSample.Models.FlatViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="editor-label">Flattening Unflattening</h1>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Country) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Country") %>
                <%= Html.ValidationMessageFor(model => model.Country) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ParentName) %>
                <%= Html.ValidationMessageFor(model => model.ParentName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentCountry) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("ParentCountry") %>
                <%= Html.ValidationMessageFor(model => model.ParentCountry) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentNumber) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ParentNumber) %>
                <%= Html.ValidationMessageFor(model => model.ParentNumber) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentParentName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ParentParentName) %>
                <%= Html.ValidationMessageFor(model => model.ParentParentName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentParentNumber) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ParentParentNumber) %>
                <%= Html.ValidationMessageFor(model => model.ParentParentNumber) %>
            </div>
                
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ParentParentCountry) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("ParentParentCountry") %>
                <%= Html.ValidationMessageFor(model => model.ParentParentCountry) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

