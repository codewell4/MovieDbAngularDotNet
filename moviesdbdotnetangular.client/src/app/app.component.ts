import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface ImdbEntity {
  imdbId: string;
  title: string;
  imageUrl: string;
  favorite: boolean;
  watch: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public entityList: ImdbEntity[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getList();
  }

  getList() {
    this.http.get<ImdbEntity[]>('/imdb/list').subscribe(
      (result) => {
        this.entityList = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'moviesdbdotnetangular.client';
}
