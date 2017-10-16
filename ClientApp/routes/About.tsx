import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class About extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div className="container">
        <h1>Meet the Creators!</h1>
        <h3>Kayla and Dani are sisters from Seattle who saw the need for a good cocktail-search website and took that as an excuse to work on a project together. They enjoy nerding out over data and drinks. </h3>
        <hr />
        <div className="row">
          <div className="col s12 l6">
            <div>
              <img className="circle responsive-img" src="https://thebarback.blob.core.windows.net/images/The-SnapBar-555-X3.jpg" />
            </div>
          </div>
          <div className="col s12 l6">
            <blockquote>Dani is an avid baker, rock-climber, and artist in addition to the front-end developer for this site. Her favorite cocktails are the fresh and summery 'Baroness Collins' and anything with Campari in it. </blockquote>
            <div className="recipe-snippet">
              <h4>Baroness Collins</h4>
              <ul>
                <li>1½ oz. gin</li>
                <li>½ oz. Campari</li>
                <li>1 oz. fresh lime juice</li>
                <li>¾ oz. simple syrup (1:1)</li>
                <li>6 fresh mint leaves</li>
                <li>Club soda</li>
              </ul>
              Tools: Muddler, shaker, strainer
              <br />
              Glass: Collins
              <br />
              Garnish: fresh mint sprig and grapefruit twist
              <br />
              <br />

              Gently muddle the mint in the base of a shaker. Combine remaining ingredients, except club soda, and shake with ice. Strain into an ice-filled glass, top with soda and garnish.
              <br/><br/>
              <em>Julian Goglia, <a href="http://www.pinewoodtr.com/">The Pinewood Tippling Room</a>, Decatur, Georgia</em>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col s12 l6">
            <blockquote>Kayla is the data mastermind behind this project. She loves organizing messes and meticulous cross-stitching projects. Her favorite drink is Beretta's Pamplemousse, a fun and floral gin concoction.</blockquote>
            <div className="recipe-snippet">
              <h4>Beretta's Pamplemousse</h4>
              <ul>
                <li>1 oz gin</li>
                <li>1 ounce freshly squeezed juice from a grapefruit</li>
                <li>1/2 ounce freshly squeezed juice from 1 lemon</li>
                <li>1/2 ounce elderflower liqueur, such as St. Germain</li>
              </ul>
              Tools: Shaker, strainer
              <br />
              Glass: Coupe
              <br />
              Garnish: Grapefruit twist
              <br />
              <br />

              Combine gin, grapefruit juice, lemon juice, and elderflower liqueur in a cocktail shaker. Fill with ice and shake until well chilled, about 15 seconds. Strain into cocktail glass, garnish with basil leaf, and serve immediately. <a href="http://www.seriouseats.com/recipes/2013/03/brunch-drink-beretta-pamplemousse-elderflower-grapefruit-gin-cocktail-recipe.html"></a>
              <br/><br/>
              <em>Ryan Fitzgerald at Beretta in San Francisco</em>
            </div>
            </div>
          <div className="col s12 l6">
            <div>
              <img className="circle responsive-img" src="https://thebarback.blob.core.windows.net/images/DSCF2391.JPG"/>
            </div>
          </div>
        </div>
      </div >
    );
  }
}