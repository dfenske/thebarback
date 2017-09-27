import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Surprise extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div className="container">
        <h3>May we kindly suggest...</h3>
        <h2>The Berlioni</h2>
        <div className="row">
          <div className="col s6">
            <h4>Description</h4>
            <div className="description">
              Over a strong gin base, the Cynar lends a delcious bitter, vegetal flavour, with the dry vermouth lending some floral notes and also helping to emphasise the sweet characteristics of the amaro. The way the three ingredients work together is really delicious, and the resulting cocktail is at once reminiscent of the Negroni, yet distinct in its own right.
        </div>
            <h4>Ingredients</h4>
            <ul className="ingredients">
              <li>1 oz Tanqueray dry gin</li>
              <li>⅔ oz Cynar</li>
              <li>½ oz Noilly Prat dry vermouth</li>
            </ul>
            <h4>Directions</h4>
            <div className="directions">Stir over ice then strain in to an ice filled old-fashioned glass. Garnish with a large twist of orange zest.</div>
            <h5><em>Credit: Gonçalo De Sousa Monteiro, Berlin bartender and Traveling Mixologist</em></h5>
            <a href="http://ohgo.sh/archive/amaro-cynar-negroni-variation-berlioni/"></a>
          </div>
          <div className="col-s6">
            <img src="https://thebarback.blob.core.windows.net/images/berlioni.jpg" className="cocktail-image"/>
          </div>
        </div>
      </div>
    );
  }
}