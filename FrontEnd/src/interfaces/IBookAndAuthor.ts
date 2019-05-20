import { IAuthor } from "./IAuthor";

export interface IBookAndAuthor {
  id: number;
  bookId: number;
  authorId: number;
  author: IAuthor;
}
