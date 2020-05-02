using System;

namespace ViewModel
{
    public class Job
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime MaxExecutionDate { get; set; }
        public int EstimatedTime { get; set; }
    }
}
