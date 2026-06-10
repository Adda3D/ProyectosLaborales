using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.TableModel
{

    public enum DataTableAjaxOrderTypes
    {
        Default = 0,
        Index,
        Name,
        OrderName
    }

    public class DataTableRequest
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public List<ColumnDataTable> columns { get; set; }
        public OrderDataTable order { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public SearchDataTable search { get; set; }

        //public DataTableAjaxOrderTypes DataTableAjaxOrderType { get; set; }
        //public int StartIndexColumn { get; set; }
        
        public int Skip
        {
            get
            {
                return this.start;
            }
        }
        public int PageSize { get { return this.length; } }

        public string SearchValue
        {
            get
            {
                return (this.search != null) ? this.search.value : null;
            }
        }
        public string SortColumnDir
        {
            get
            {
                return (this.order != null) ? order.dir : null;
            }
        }
        
        public string SortColumn
        {
            get
            {
                return (this.order != null) ? columns[order.column].data : null;
            }
        }
        /*
        public int SortOrderColumn
        {
            get
            {
                return (this.order != null) ? order.column + 1 : -1;
            }
        }
        */
    }

    public class ColumnDataTable
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public SearchDataTable search { get; set; }
        //public bool isCustom { get; set; }
        //public DataTableColumnTypes columnType { get; set; }
        //public List<Column> columns { get; set; }
        //public string orderName { get; set; }
    }

    public class SearchDataTable
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class OrderDataTable
    {
        public int column { get; set; }
        public string dir { get; set; }
    }


}