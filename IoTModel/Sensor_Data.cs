namespace IoTModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sensor_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sensor_Data()
        {
            Aggregator_Data = new HashSet<Aggregator_Data>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sensor_data_id { get; set; }

        public int sensor_id { get; set; }

        public int thing_id { get; set; }

        public DateTime? dateandtime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aggregator_Data> Aggregator_Data { get; set; }

        public virtual Sensor Sensor { get; set; }

        public virtual Thing Thing { get; set; }
    }
}
