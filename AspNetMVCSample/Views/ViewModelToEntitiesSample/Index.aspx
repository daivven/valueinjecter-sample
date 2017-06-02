<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AspNetMVCSample.Models.FooBarViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ViewModel to/from entities</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Foo</legend>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.FooName) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.FooName) %>
            <%= Html.ValidationMessageFor(model => model.FooName) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.FooText) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.FooText) %>
            <%= Html.ValidationMessageFor(model => model.FooText) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.FooCountry) %>
        </div>
        <div class="editor-field">
            <%= Html.DropDownList("FooCountry") %>
            <%= Html.ValidationMessageFor(model => model.FooCountry) %>
        </div>
    </fieldset>
    <fieldset>
        <legend>Bar</legend>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.BarName) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.BarName) %>
            <%= Html.ValidationMessageFor(model => model.BarName) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.BarText) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.BarText) %>
            <%= Html.ValidationMessageFor(model => model.BarText) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.BarCountry) %>
        </div>
        <div class="editor-field">
            <%= Html.DropDownList("BarCountry") %>
            <%= Html.ValidationMessageFor(model => model.BarCountry) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.BarNumber) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.BarNumber) %>
            <%= Html.ValidationMessageFor(model => model.BarNumber) %>
        </div>
    </fieldset>
    <p>
        <input type="submit" value="Submit" />
    </p>
    <% } %>

</asp:Content>
