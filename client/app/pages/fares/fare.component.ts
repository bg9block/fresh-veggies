import { Component, OnInit } from '@angular/core';
import { Fare } from './fares.models'
import { FaresService } from '../../services/fares.service';
import { IPFSService } from '../../services/ipfs.service';

@Component({
  selector: 'fare',
  templateUrl: './fare.component.html',
  styleUrls: ['./fare.component.css']
})
export class FareComponent implements OnInit {
  consumerName: String;
  farmerName: String;

  constructor(private ipfsService: IPFSService ) { }

  manifestAgreement() {
    this.ipfsService.manifestAgreement({farmerName: this.farmerName, consumerName: this.consumerName})
    .then((data) => {
      alert(data? data.hash: "empty");
    })
    .catch((err) => {
      alert(err);
    });
  }

  ngOnInit() {
  }
}
