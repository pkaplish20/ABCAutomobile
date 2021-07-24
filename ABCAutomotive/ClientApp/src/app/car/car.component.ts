import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  constructor(private service: SharedService) { }
  date: any;
  maxProfit: number = 0;
  maxProfitCar: string="";
  carList: any[];
  ngOnInit(): void {   
  }

  //after entering date method returns car list
  display() {
    this.service.getCarList(this.date)
      .subscribe(data => {
        this.carList = data;
        for (let i of this.carList) {
          if (i.profit > this.maxProfit) {
            this.maxProfitCar = i.carModel;
          }
        }
    });
  }

  }
 
