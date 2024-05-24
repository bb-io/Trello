using Apps.Trello.Models.Entities;

namespace Apps.Trello.Models.Responses.CustomField;

public record ListCustomFieldsResponse(CustomFieldEntity[] Fields);