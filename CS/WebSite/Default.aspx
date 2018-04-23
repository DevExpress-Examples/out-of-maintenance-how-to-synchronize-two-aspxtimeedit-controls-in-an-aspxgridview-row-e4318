<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to synchronize two ASPxTimeEdit controls in an ASPxGridView row</title>
    <script type="text/javascript">
        var oldDate;

        function GetTime(s, index) {
            oldDate = s.GetDate();
            var timeEdit = eval("to" + index);
            timeEdit.Focus();
        }
        function ChangeTime(s, index) {
            s.Focus();
            if (oldDate) {
                var newDate = s.GetDate();
                var d = newDate.getTime() - oldDate.getTime();
                var timeEdit = eval("to" + index);
                var date = timeEdit.GetDate().getTime() + d;
                timeEdit.SetDate(new Date(date));
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" KeyFieldName="ID">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" />
                <dx:GridViewDataTextColumn FieldName="From" VisibleIndex="2">
                    <DataItemTemplate>
                        <dx:ASPxTimeEdit ID="fromTimeEdit" runat="server" DateTime='<%# Bind("From") %>'
                            ClientSideEvents-ButtonClick='<%# "function (s, e) { GetTime(s, " + Container.VisibleIndex + "); }" %>'
                            ClientSideEvents-KeyUp='<%# "function (s, e) { GetTime(s, " + Container.VisibleIndex + "); }" %>'
                            ClientSideEvents-ValueChanged='<%# "function (s, e) { ChangeTime(s, " + Container.VisibleIndex + "); }" %>'
                            EditFormat="DateTime" />
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="To" VisibleIndex="3">
                    <DataItemTemplate>
                        <dx:ASPxTimeEdit ID="toTimeEdit" runat="server" DateTime='<%#Bind("To")%>'
                            ClientInstanceName='<%#String.Format("to{0}", Container.VisibleIndex)%>'
                            EditFormat="DateTime" />
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    </form>
</body>
</html>
