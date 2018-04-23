using System;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    private DataTable table;

    private DataTable DataTable {
        get {
            if(Session["DataTable"] == null) {
                InitializeDataTable();
                Session["DataTable"] = table;
            }
            table = (DataTable)Session["DataTable"];
            return table;
        }
    }

    protected void Page_Init(object sender, EventArgs e) {
        gv.DataSource = DataTable;
    }

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack)
            gv.DataBind();
    }

    private void InitializeDataTable() {
        table = new DataTable("Table");
        DataColumn column;

        column = new DataColumn();
        column.DataType = typeof(int);
        column.ColumnName = "ID";
        table.Columns.Add(column);

        table.PrimaryKey = new DataColumn[] { column };

        column = new DataColumn();
        column.DataType = typeof(DateTime);
        column.ColumnName = "From";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = typeof(DateTime);
        column.ColumnName = "To";
        table.Columns.Add(column);

        PopulateDataTable();
    }

    private void PopulateDataTable() {
        DataRow row;
        DateTime d = DateTime.Now;
        for(int i = 0; i < 2; i++) {
            row = table.NewRow();
            row["ID"] = i;
            row["From"] = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            row["To"] = new DateTime(d.Year, d.Month, d.Day + 1, d.Hour + 1, d.Minute, d.Second);
            table.Rows.Add(row);
        }
    }
}