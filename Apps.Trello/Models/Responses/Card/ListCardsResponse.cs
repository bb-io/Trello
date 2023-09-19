using Apps.Trello.Models.Entities;

namespace Apps.Trello.Models.Responses.Card;

public record ListCardsResponse(CardEntity[] Cards);