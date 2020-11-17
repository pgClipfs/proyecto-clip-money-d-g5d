import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  accounts = [
    {
      amount: '12045.0',
      type: 'Pesos'
    },
    {
      amount: '600.02',
      type: 'U$D'
    },
    {
      amount: '0.0005',
      type: 'BTC'
    }
  ]

}
