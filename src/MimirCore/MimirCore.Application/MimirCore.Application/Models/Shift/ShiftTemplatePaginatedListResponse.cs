using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Shift;

// Shift Template Paginated List Response
public class ShiftTemplatePaginatedListResponse : PaginatedListResponse<ShiftTemplateItemListDto>
{
    public ShiftTemplatePaginatedListResponse() : base() { }
    
    public ShiftTemplatePaginatedListResponse(IList<ShiftTemplateItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new ShiftTemplatePaginatedListResponse Create(IList<ShiftTemplateItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new ShiftTemplatePaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}