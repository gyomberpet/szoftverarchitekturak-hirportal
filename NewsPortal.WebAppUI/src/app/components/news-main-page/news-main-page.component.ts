import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';

const TEMP_NEWS = [
  {
    title: 'Earthquake Shakes California',
    subtitle: 'Residents Urged to Stay Safe',
    category: 'Natural Disasters',
    description:
      'A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.',
    imageUrl: 'https://picsum.photos/500/500',
    isTrending: false,
  },
  {
    title: 'New COVID-19 Variant Detected',
    subtitle: 'Health Officials Monitor Situation',
    category: 'Health',
    description:
      'A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.',
    imageUrl: 'https://picsum.photos/600/600',
    isTrending: false,
  },
  {
    title: 'Tech Giant Launches New Smartphone',
    subtitle: 'Features High-Resolution Camera',
    category: 'Technology',
    description:
      'Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.',
    imageUrl: 'https://picsum.photos/700/700',
    isTrending: false,
  },
  {
    title: 'Record-Breaking Heatwave Hits Europe',
    subtitle: 'Heatwave Expected to Last',
    category: 'Weather',
    description:
      'Europe is sweltering under an unprecedented heatwave, with temperatures soaring above 100°F. Meteorologists predict the heatwave will persist for the next several days.',
    imageUrl: 'https://picsum.photos/800/800',
    isTrending: false,
  },
  {
    title: 'Olympic Games Begin in Tokyo',
    subtitle: 'Athletes Gear Up for Competition',
    category: 'Sports',
    description:
      'The Tokyo Olympics officially kick off, with athletes from around the world ready to compete in various sports events, albeit under the shadow of COVID-19 precautions.',
    imageUrl: 'https://picsum.photos/900/900',
    isTrending: false,
  },
];

@Component({
  selector: 'app-news-main-page',
  templateUrl: './news-main-page.component.html',
  styleUrls: ['./news-main-page.component.css'],
})
export class NewsMainPageComponent implements OnInit {
  newsList: News[];

  ngOnInit(): void {
    this.newsList = TEMP_NEWS;
  }
}
