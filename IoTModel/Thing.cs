namespace IoTModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thing")]
    public partial class Thing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thing()
        {
            Sensor_Data = new HashSet<Sensor_Data>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int thing_id { get; set; }

        [StringLength(30)]
        public string thing_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensor_Data> Sensor_Data { get; set; }
    }
}
