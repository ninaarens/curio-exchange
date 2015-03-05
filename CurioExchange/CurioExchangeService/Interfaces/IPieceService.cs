﻿using CurioExchangeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurioExchangeService
{
    [ServiceContract]
    public interface IPieceService
    {
        [OperationContract]
        Task<ICollection<Piece>> RetrievePieces();

        [OperationContract]
        Task<int> GetPieceIdForName(string set, string piece);
    }
}
