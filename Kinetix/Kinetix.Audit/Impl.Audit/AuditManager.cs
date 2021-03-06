﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kinetix.Audit
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public sealed class AuditManager : IAuditManager
    {
        private readonly IAuditTraceStorePlugin _auditTraceStorePlugin;

        public AuditManager(IAuditTraceStorePlugin auditTraceStorePlugin)
        {
            _auditTraceStorePlugin = auditTraceStorePlugin;
        }

        public void AddTrace(AuditTrace auditTrace)
        {
            _auditTraceStorePlugin.CreateTrace(auditTrace);
        }

        public IList<AuditTrace> FindTrace(AuditTraceCriteria auditTraceCriteria)
        {
            return _auditTraceStorePlugin.FindTraceByCriteria(auditTraceCriteria);
        }

        public AuditTrace GetTrace(int idAuditTrace)
        {
            return _auditTraceStorePlugin.ReadTrace(idAuditTrace);
        }

    }
}
