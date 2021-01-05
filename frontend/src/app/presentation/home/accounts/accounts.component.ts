import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AccountsComponent implements OnInit {

  @Input() accounts: any[];

  constructor() { }

  ngOnInit(): void {
    console.log(this.accounts);
  }

}
