import { Image } from "./image";
import { NewsCategory } from "./newsCategory";

export class News {
  public id?: number;
  public title?: string;
  public subtitle?: string;
  public category: NewsCategory;
  public content?: string;
  public startDate:string //Date = new Date(Date.now())
  public endDate:string //Date = new Date(Date.now())
  public isTrending?: boolean;
  public image?: Image;
  
}
