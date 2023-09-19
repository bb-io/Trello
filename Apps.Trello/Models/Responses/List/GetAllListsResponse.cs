using Apps.Trello.Models.Entities;

namespace Apps.Trello.Models.Responses.List;

public record GetAllListsResponse(ListEntity[] Lists);