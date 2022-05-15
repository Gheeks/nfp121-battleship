import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ColDef, GetRowIdFunc, GetRowIdParams, GridApi, GridOptions, GridReadyEvent, ICellRendererParams, IDatasource, IGetRowsParams, SortModelItem } from 'ag-grid-community';

@Component({
  selector: 'stats-grid',
  templateUrl: './stats-grid.component.html',
  styleUrls: ['./stats-grid.component.sass']
})
export class StatsGridComponent implements OnInit {
  public columnDefs: ColDef[] = [
    // this row just shows the row index, doesn't use any data from the row
    {
      headerName: 'ID',
      maxWidth: 100,
      valueGetter: 'node.id',
      cellRenderer: function (params: ICellRendererParams) {
        if (params.value !== undefined) {
          return params.value;
        } else {
          return '<img src="https://www.ag-grid.com/example-assets/loading.gif">';
        }
      },
      // we don't want to sort by the row index, this doesn't make sense as the point
      // of the row index is to know the row index in what came back from the server
      sortable: false,
      suppressMenu: true,
    },
    { headerName: 'Athlete', field: 'athlete', suppressMenu: true },
    {
      field: 'age',
      filter: 'agNumberColumnFilter',
    },
    {
      field: 'country',
      filter: 'agSetColumnFilter',
    },
    {
      field: 'year',
      filter: 'agSetColumnFilter',
      filterParams: { values: ['2000', '2004', '2008', '2012'] },
    },
    { field: 'date' },
    { field: 'sport', suppressMenu: true },
    { field: 'gold', suppressMenu: true },
    { field: 'silver', suppressMenu: true },
    { field: 'bronze', suppressMenu: true },
    { field: 'total', suppressMenu: true },
  ];

  public rowModelType = 'infinite';
  public rowData!: any[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  onGridReady(params: GridReadyEvent) {
    this.http
      .get<any[]>('https://www.ag-grid.com/example-assets/olympic-winners.json')
      .subscribe((data) => {
        data.forEach(function (d: any, index: number) {
          d.id = 'R' + (index + 1);
        });
        const dataSource: IDatasource = {
          rowCount: undefined,
          getRows: function (params: IGetRowsParams) {
            console.log(
              'asking for ' + params.startRow + ' to ' + params.endRow
            );
            // At this point in your code, you would call the server.
            // To make the demo look real, wait for 500ms before returning

            setTimeout(function () {
              // take a slice of the total rows
              const rowsThisPage = data.slice(
                params.startRow,
                params.endRow
              );
              // if on or after the last page, work out the last row.
              let lastRow = -1;
              if (data.length <= params.endRow) {
                lastRow = data.length;
              }
              // call the success callback
              params.successCallback(rowsThisPage, lastRow);
            }, 500);
          },
        };
        params.api!.setDatasource(dataSource);
      });
  }
}
