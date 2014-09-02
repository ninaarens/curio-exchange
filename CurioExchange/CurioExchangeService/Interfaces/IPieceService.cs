﻿using CurioExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurioExchangeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPieceService" in both code and config file together.
    [ServiceContract]
    public interface IPieceService
    {
        [OperationContract]
        Task<ICollection<Piece>> RetrievePieces();
    }
}
