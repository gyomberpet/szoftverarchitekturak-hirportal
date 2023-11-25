import { Component } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';
import { NewsCategoryService } from 'src/app/service/news-category.service';
import { NewsCategory } from 'src/app/models/newsCategory';

const NEWS_EXPIRATION_IN_DAYS = 14;

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrls: ['./create-news.component.css'],
})
export class CreateNewsComponent {
  selectedFile: File | null;

<<<<<<< Updated upstream
  constructor(private newsService: NewsService) {}

  onFileSelected(event: any) {
=======
  constructor(private newsService: NewsService, private route: ActivatedRoute, private newsCategoryService: NewsCategoryService) {}

  categories: NewsCategory[] = [];

  selectedCategory: NewsCategory;
  addingNewCategory = false;
  newCategory: NewsCategory;

  ngOnInit(): void {
    
    this.loadCategories();
    const id = this.route.snapshot.paramMap.get('id')!;
  
    if (id) {
      this.newsService.getNewsById(id).subscribe({
        next: (res: News) => {
          this.editingNews = res;
          this.news = { ...res };
          this.news.endDate = this.news.endDate.split('T')[0]; // Format endDate for the date input
        },
        error: (err) => console.error(err),
      });
    }
  }

  loadCategories() {
    this.newsCategoryService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  onFileSelected(event: any): void {
>>>>>>> Stashed changes
    this.selectedFile = event.target.files[0] as File;
  }

  createNews() {
    if (!this.selectedFile) return;

    this.encodeImageToBase64(this.selectedFile).subscribe({
      next: (res) => {
        let base64image = res;

        let currentDate = new Date();
        let expirationDate = new Date(
          currentDate.setDate(currentDate.getDate() + NEWS_EXPIRATION_IN_DAYS)
        );
        let news: News = {
      
          title: 'teszt',
          subtitle: 'sub teszt',
          category: {
            name: 'tt',
          },
          content: 'piuasdhhfwaipefwuqefwwefuqwef',
          startDate: currentDate.toISOString(),
          endDate: expirationDate.toISOString(),
          isTrending: true,
          image: {
            data: base64image,
          },
        } as News;

        this.newsService.createNews(news).subscribe({
          next: (res) => console.log(res),
          error: (err) => console.error(),
        });
      },
      error: (err) => console.error(err),
    });
  }

  encodeImageToBase64(file: File): Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = (event) =>
      result.next(btoa(event?.target?.result?.toString() ?? ''));
    return result;
  }
}
