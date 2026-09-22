using System;
using System.Collections.Generic;
using System.Text;

namespace CSMS.DAL.Enums
{
    public enum Status
    {
        Entered,
        UnderDIagnosis,
        DiagnosesSentToCustomer,
        serviceApproved,
        serviceRejected,
        servicing,
        ended,
    }
}
