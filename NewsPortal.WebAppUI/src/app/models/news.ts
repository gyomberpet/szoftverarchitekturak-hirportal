import { Image } from "./image";
import { NewsCategory } from "./newsCategory";

export class News {
  public id: number;
  public title?: string;
  public subtitle?: string;
  public category: NewsCategory;
  public description?: string;
  public publishedAt:string //Date = new Date(Date.now())
  public expiredAt:string //Date = new Date(Date.now())
  public createBy:string
  public isTrending?: boolean;
  public image?: Image;
  public imageUrl?: string;
}
