import { Component, OnInit } from '@angular/core';
import { Fare } from './fares.models'
import { FaresService } from '../../services/fares.service';

@Component({
  selector: 'fares-list',
  templateUrl: './fares.component.html',
  styleUrls: ['./fares.component.css']
})
export class FaresListComponent implements OnInit {

  constructor(private FaresService: FaresService) { }

  fares: Array<Fare>

  ngOnInit() {
      var that = this;
      this.FaresService.getAllFares()
        .then(response => {that.fares = response;});
  }

}
