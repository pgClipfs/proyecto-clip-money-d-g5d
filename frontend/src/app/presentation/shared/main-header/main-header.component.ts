import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-main-header',
  templateUrl: './main-header.component.html',
  styleUrls: ['./main-header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MainHeaderComponent implements OnInit {

  @Input() title: string;
  @Input() icon: string;
  @Input() arrow: 'left' | 'right' | 'none';
  @Input() navigation: string;
  constructor() { }

  ngOnInit(): void {
  }

  goTo(){
    document.location.href = this.navigation
  }

}
