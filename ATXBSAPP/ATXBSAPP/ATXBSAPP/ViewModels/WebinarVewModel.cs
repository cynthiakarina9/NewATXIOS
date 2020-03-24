using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.ViewModels
{
    class WebinarVewModel
    {
        public class ValueW
        {
            public string adx_name { get; set; }
            public string new_descripcion { get; set; }
            public string adx_releasedate { get; set; }
            public string new_urlimagen { get; set; }
            public string new_linkpost { get; set; }
            public string createdby { get; set; }
        }
        public class RootObject
        {
            public List<ValueW> value { get; set; }
        }
    }
}
