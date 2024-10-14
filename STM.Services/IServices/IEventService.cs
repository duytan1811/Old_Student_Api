namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Events;

    public interface IEventService
    {
        Task<IQueryable<EventDto>> Search(EventSearchDto dto);

        Task<IQueryable<EventRegisterDto>> GetUserRegisters(Guid eventId, EventRegisterSearchDto dto);

        Task<EventDto?> FindById(Guid id, Guid currentId);

        Task<string> Create(EventSaveDto dto);

        Task<string> Update(EventSaveDto dto);

        Task<string> Delete(Guid id);

        Task<string> Register(Guid id, EventRegisterSaveDto dto);
    }
}
