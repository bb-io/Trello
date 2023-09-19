using Apps.Trello.Models.Entities;

namespace Apps.Trello.Models.Responses.Board;

public record ListBoardsResponse(BoardEntity[] Boards);