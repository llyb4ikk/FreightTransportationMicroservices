using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface ITransportationService
    {
        Task<TransportationDTO> GetTransportationByIdAsync(int id);
        Task<IEnumerable<TransportationDTO>> GetAllTransportationsAsync();
        Task<TransportationDTO> AddTransportationAsync(TransportationDTO transportationDto);
        Task<TransportationDTO> EditTransportationAsync(TransportationDTO transportationDto);
        Task<bool> DeleteTransportationAsync(int id);

        Task<IEnumerable<TransportationTableDTO>> GetAllTransportationsTable();
        Task<TransportationDetailsDTO> GetTransportationDetailsById(int id);
        Task<bool> NextStageAsync(int transportationId);

        Task<bool> SetDriversToTransportyation(int transportationId, IEnumerable<int> carDriversIds);
    }
}