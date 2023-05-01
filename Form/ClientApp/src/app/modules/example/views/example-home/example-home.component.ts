import { AfterViewInit, Component, Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-example-home',
  templateUrl: './example-home.component.html',
  styleUrls: ['./example-home.component.scss']
})
export class ExampleHomeComponent implements OnInit {
  bricks = [1,2,3,4,5,6,7]
  products = [
    { code:123,name:'456',category:789,quantity:-1 },
    { code:123,name:'456',category:789,quantity:-1 },
    { code:123,name:'456',category:789,quantity:-1 },
    { code:123,name:'456',category:789,quantity:-1 }
  ]
  constructor() { }

  ngOnInit(): void {
  }

}

@Directive({
  selector:'div [rwd]',
})
export class RWD implements OnInit{
  //col,md,lg
  @Input() rwd = '12,12,12';
  constructor(
    private el:ElementRef, private renderer: Renderer2
  ){
  }
  ngOnInit(): void {
    let rwds = this.rwd.split(',');
    console.log(this.rwd)
    if(rwds[0]){
      this.el.nativeElement.classList.add(`col-${rwds[0]}`);
    }
    if(rwds[1]){
      this.el.nativeElement.classList.add(`md:col-${rwds[1]}`);
    }
    if(rwds[2]){
      this.el.nativeElement.classList.add(`lg:col-${rwds[2]}`);
    }
  }
}

@Component({
  selector:'div [input-group]',
  template:`
  <ng-content></ng-content>  `,
})
export class InputGroupContainer{
  constructor(private el:ElementRef){
    this.el.nativeElement.classList.add('p-inputgroup');
  }
}
@Component({
  selector:'span [addon]',
  template:`
  {{label}}
  <ng-content></ng-content>`,
})
export class InputGroupAddOn implements OnInit{
  @Input() label='';
  @Input() style='';
  @Input() class='';
  constructor(private el:ElementRef){
    this.el.nativeElement.classList.add('p-inputgroup-addon');
  }
  ngOnInit(): void {
      let classList = this.class.split(' ');
      classList.forEach(cl => {
        if(cl){
          this.el.nativeElement.classList.add(cl);
        }
      })
      this.el.nativeElement.style = this.style;
  }
}