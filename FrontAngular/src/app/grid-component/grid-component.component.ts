import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-component',
  templateUrl: './grid-component.component.html',
  styleUrls: ['./grid-component.component.sass']
})
export class GridComponentComponent implements OnInit {

  public gridSize: number = 8;

  constructor() { }

  ngOnInit(): void {
  }

}
