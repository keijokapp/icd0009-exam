import { IBookAndAuthor } from "./IBookAndAuthor";
import { IComment } from "./IComment";

export interface IBook {
  id: number;
  title: string,
  publishingYear: number,
  bookAndAuthors: IBookAndAuthor[],
  comments: IComment[],
}
