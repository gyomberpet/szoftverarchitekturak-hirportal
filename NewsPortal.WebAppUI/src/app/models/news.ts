export class News {
  public id: number;
  public title?: string;
  public subtitle?: string;
  public category?: string;
  public description?: string;
  public imageUrl?: string;
  public publishedAt:string //Date = new Date(Date.now())
  public expiredAt:string //Date = new Date(Date.now())
  public createBy:string
  public isTrending?: boolean;
}
