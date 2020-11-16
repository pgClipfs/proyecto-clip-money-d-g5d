import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TransactionComponent implements OnInit {

  @Input() title: string;
  @Input() 
  set state(state: 'ok' | 'success' | 'error' | string){
    this.stateClass = `transaction__status--${state}`
  }
  get state(){
    return this.stateClass;
  }
  private stateClass: string;
  constructor() { }

  ngOnInit(): void {
  }

}
