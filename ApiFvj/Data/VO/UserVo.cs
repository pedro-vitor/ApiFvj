using ApiFvj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.VO
{
    public class UserVO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserVO()
        {
            this.Lead = new HashSet<Lead>();
            this.Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public System.DateTime createdat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lead> Lead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

    }
}