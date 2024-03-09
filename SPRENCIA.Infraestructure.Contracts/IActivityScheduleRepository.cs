using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityScheduleRepository
    {
        Task<ActivitiyScheduleDto> Create(ActivitiyScheduleDto activityScheduleDto);
    }
}
