<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AspNetMVCSample.Models.PersonViewModel>" %>

            <%=Html.HiddenFor(o => o.Id) %>
                                    
            <div class="editor-label">
                <%= Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.FirstName) %>
                <%= Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LastName) %>
                <%= Html.ValidationMessageFor(model => model.LastName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.MiddleName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.MiddleName) %>
                <%= Html.ValidationMessageFor(model => model.MiddleName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Age) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Age) %>
                <%= Html.ValidationMessageFor(model => model.Age) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.IsTrue) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.IsTrue) %>
                <%= Html.ValidationMessageFor(model => model.IsTrue) %>
            </div>

            <div class="editor-field">
                One<%=Html.RadioButtonFor(model => model.Radio, 1) %>
                Two<%=Html.RadioButtonFor(model => model.Radio, 2) %>
                Three<%=Html.RadioButtonFor(model => model.Radio, 3) %>
            </div>
                        
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Country) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Country") %>
                <%= Html.ValidationMessageFor(model => model.Country) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Country2) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Country2") %>
                <%= Html.ValidationMessageFor(model => model.Country2) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Country3) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Country3") %>
                <%= Html.ValidationMessageFor(model => model.Country3) %>
            </div>