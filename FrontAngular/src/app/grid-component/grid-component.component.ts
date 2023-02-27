import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-component',
  templateUrl: './grid-component.component.html',
  styleUrls: ['./grid-component.component.scss'],
})
export class GridComponentComponent implements OnInit {
  public gridSize: number = 8;
  public torpedoOnGrid = false;
  public destroyer1OnGrid = false;
  public destroyer2OnGrid = false;
  public cruiser1OnGrid = false;
  public cruiser2OnGrid = false;
  public aircraftOnGrid = false;
  public placementEnd = false;

  constructor() {}

  ngOnInit(): void {}
}
